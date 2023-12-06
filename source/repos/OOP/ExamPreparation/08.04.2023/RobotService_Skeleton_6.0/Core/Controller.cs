using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private RobotRepository robots;
        private SupplementRepository supplements;

        public Controller()
        {
            robots = new RobotRepository();
            supplements = new SupplementRepository();
        }
        public string CreateRobot(string model, string typeName)
        {
            if (typeName != "DomesticAssistant" && typeName != "IndustrialAssistant")
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            IRobot robot;
            if (typeName == "DomesticAssistant")
            {
                robot = new DomesticAssistant(model);
            }
            else
            {
                robot = new IndustrialAssistant(model);
            }
            robots.AddNew(robot);
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != "SpecializedArm" && typeName != "LaserRadar")
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }
            ISupplement supplement;
            if (typeName == "SpecializedArm")
            {
                supplement = new SpecializedArm();
            }
            else
            {
                supplement = new LaserRadar();
            }
            supplements.AddNew(supplement);
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            IEnumerable<IRobot> filteredRobots = robots.Models().Where(r => r.InterfaceStandards.Contains(intefaceStandard)).OrderByDescending(r => r.BatteryLevel);

            if (filteredRobots.Count() == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }
            int sumBatteryLevel = filteredRobots.Sum(r => r.BatteryLevel);
            if (sumBatteryLevel < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sumBatteryLevel);
            }

            int counter = 0;

            foreach (var robot in filteredRobots )
            {
              
                    if (robot.BatteryLevel >= totalPowerNeeded)
                    {
                        robot.ExecuteService(totalPowerNeeded);
                        totalPowerNeeded = 0;
                        counter++;

                    }
                    else
                    {
                        totalPowerNeeded -= robot.BatteryLevel;
                        robot.ExecuteService(robot.BatteryLevel);
                        counter++;
                    }
                if (totalPowerNeeded<=0)
                {
                    break;
                }

            }



            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, counter);
        }

        public string Report()
        {
           StringBuilder sb = new StringBuilder();
            foreach (var robot in robots.Models().OrderByDescending(r=>r.BatteryLevel).ThenBy(r=>r.BatteryCapacity))
            {
                sb.AppendLine(robot.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            IEnumerable<IRobot> hubgryRobots = robots.Models()
                .Where(r=>r.Model== model && r.BatteryCapacity/2 >r.BatteryLevel);

            int robotFed = 0;
            foreach (var robot in hubgryRobots)
            {
                robot.Eating(minutes);
                robotFed++;
            }

            return string.Format(OutputMessages.RobotsFed,robotFed);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().First(s => s.GetType().Name == supplementTypeName);
            int supplementValue = supplement.InterfaceStandard;
            IEnumerable<IRobot> notSupportingInterfaceRobots = robots.Models().Where(r => !r.InterfaceStandards.Contains(supplementValue));
            IEnumerable<IRobot> sameModelRobots = notSupportingInterfaceRobots.Where(r => r.Model == model);
            if (sameModelRobots.Count() == 0)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }
            else
            {
                IRobot robotToUpgrade = sameModelRobots.First();
                robotToUpgrade.InstallSupplement(supplement);
                supplements.RemoveByName(supplementTypeName);
                return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
            }
        }
    }
}
