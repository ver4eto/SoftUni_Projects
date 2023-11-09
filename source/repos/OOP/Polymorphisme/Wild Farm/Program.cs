using Wild_Farm.Core;
using Wild_Farm.Core.Interfaces;
using Wild_Farm.Factory;
using Wild_Farm.Factory.Interfaces;
using Wild_Farm.IO;
using Wild_Farm.IO.Interfaces;

IReader reader = new Reader();
IWriter writer = new Writer();
IAnimalFactory animalFactory = new AnimalFactory();
IFoodFactory foodFactory = new FoodFactory();

IEngine engine = new   Engine(reader, writer, animalFactory, foodFactory);

engine.Run();