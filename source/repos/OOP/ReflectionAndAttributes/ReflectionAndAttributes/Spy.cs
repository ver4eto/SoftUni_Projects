using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClass, params string[] values)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {nameOfClass}");
            Type classType = Type.GetType(nameOfClass);

            FieldInfo[] classInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);


            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            foreach (FieldInfo info in classInfo.Where(c => values.Contains(c.Name)))
            {
                sb.AppendLine($"{info.Name} = {info.GetValue(classInstance)}");

            }
            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {

            Type classType = AppDomain.CurrentDomain
    .GetAssemblies()
    .SelectMany(x => x.GetTypes())
    .FirstOrDefault(t => t.Name == className);

            //Type classType = Type.GetType(className);
            FieldInfo[] fieldsInfo = classType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();
            foreach (FieldInfo fieldInfo in fieldsInfo)
            {
                sb.AppendLine($"{fieldInfo.Name} must be private!");
            }

            foreach (var method in publicMethods)
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (var method in nonPublicMethods)
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {

            Type classType = Type.GetType(className);

            MethodInfo[] methodInfos = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {className}" + Environment.NewLine+
                $"Base Class: {classType.BaseType.Name}");
            foreach (MethodInfo method in methodInfos)
            {
                sb.AppendLine($"{method.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);
            MethodInfo[] fieldInfos = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public); 

            StringBuilder sb = new StringBuilder();

            foreach (var method in fieldInfos.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in fieldInfos.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
