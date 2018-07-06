using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TallboyBLL.Models;

namespace TallboyBLL.TestData
{
    public class Data
    {
        List<TallboyBLL.Models.Task> taskList;

        List<TaskElement> taskElementList;

        List<TallboyBLL.Models.Type> typeList;

        List<Container> containerList;

        List<ContainerPart> containerPartList;

        List<ContainerPartContent> containerPartContentList;

        public Data()
        {
            taskList = new List<Models.Task>() { new Models.Task() { Id= 1, Name= "PCB soldering", Description="***rövid leírás***"} };

            taskElementList = new List<TaskElement>()
            {
                new TaskElement(){Id= 1, Name="1. Board" , Description = "Open the red drawer!", Order=1 , TaskId= 1, TypeId= 1},
                new TaskElement(){Id=2, Name="2. IC", Description = "Position the IC to the right lace",TaskId=1, TypeId=2, Order=2 },
                new TaskElement(){Id=2, Name="3. Resistor 1", Description = "Description",TaskId=1, TypeId=3, Order=3 },
                new TaskElement(){Id=2, Name="4. Resistor 2", Description = "Description",TaskId=1, TypeId=4, Order=4 },
                new TaskElement(){Id=2, Name="5. Polyfuse", Description = "Description",TaskId=1, TypeId=1, Order=5 },
                new TaskElement(){Id=2, Name="6. Capacitor", Description = "Description",TaskId=1, TypeId=1, Order=6 },
            };

            typeList = new List<Models.Type>()
            {
                new Models.Type(){Id=1, Name="Board", Description="-", UUID= "057d09e2-2bc7-4098-8ba0-ad428f3ddf41"},
                new Models.Type(){Id=2, Name="IC", Description="-", UUID= "464d6419-d6ed-4229-9509-890cd5807f9b" },
                new Models.Type(){Id=1, Name="Resistor", Description="-", UUID= "."},
                new Models.Type(){Id=2, Name="Polyfuse", Description="-", UUID= "." }
            };

            containerList = new List<Container> { new Container() { Id=1} };

            containerPartList= new List<ContainerPart>
            {
                new ContainerPart{ Id=1, XCoordinate= 0, YCoordinate= 0, Height= 55, Width= 270 },
                new ContainerPart{ Id=2, XCoordinate= 0, YCoordinate= 66, Height= 55, Width= 130 },
                new ContainerPart{ Id=3, XCoordinate= 140, YCoordinate= 66, Height= 55, Width= 130 },
                new ContainerPart{ Id=4, XCoordinate= 0, YCoordinate= 130, Height= 35, Width= 45 },
                new ContainerPart{ Id=5, XCoordinate= 55, YCoordinate= 130, Height= 35, Width= 45 },
                new ContainerPart{ Id=6, XCoordinate= 110, YCoordinate= 130, Height= 35, Width= 45 },
                new ContainerPart{ Id=7, XCoordinate= 165, YCoordinate= 130, Height= 35, Width= 45 },
                new ContainerPart{ Id=8, XCoordinate= 220, YCoordinate= 130, Height= 35, Width= 45 },
                new ContainerPart{ Id=9, XCoordinate= 0, YCoordinate= 185, Height= 35, Width= 45 },
                new ContainerPart{ Id=10, XCoordinate= 55, YCoordinate= 185, Height= 35, Width= 45 },
                new ContainerPart{ Id=11, XCoordinate= 110, YCoordinate= 185, Height= 35, Width= 45 },
                new ContainerPart{ Id=12, XCoordinate= 165, YCoordinate= 185, Height= 35, Width= 45 },
                new ContainerPart{ Id=13, XCoordinate= 220, YCoordinate= 185, Height= 35, Width= 45 },
                new ContainerPart{ Id=14, XCoordinate= 0, YCoordinate= 240, Height= 35, Width= 45 },
                new ContainerPart{ Id=15, XCoordinate= 55, YCoordinate= 240, Height= 35, Width= 45 },
                new ContainerPart{ Id=16, XCoordinate= 110, YCoordinate= 240, Height= 35, Width= 45 },
                new ContainerPart{ Id=17, XCoordinate= 165, YCoordinate= 240, Height= 35, Width= 45 },
                new ContainerPart{ Id=18, XCoordinate= 220, YCoordinate= 240, Height= 35, Width= 45 },
            };

            containerPartContentList = new List<ContainerPartContent>()
            {
                new ContainerPartContent(){Id= 1, TypeId=1, Amount=1,ContainerPartId= 5},
                new ContainerPartContent(){Id= 2, TypeId=2, Amount=2, ContainerPartId= 17},
                new ContainerPartContent(){Id= 3, TypeId=3, Amount=1,ContainerPartId= 5},
                new ContainerPartContent(){Id= 4, TypeId=4, Amount=2, ContainerPartId= 17}
            };
        }

        public List<Task> TaskList { get => taskList; set => taskList = value; }
        public List<TaskElement> TaskElementList { get => taskElementList; set => taskElementList = value; }
        public List<Models.Type> TypeList { get => typeList; set => typeList = value; }
        public List<Container> ContainerList { get => containerList; set => containerList = value; }
        public List<ContainerPart> ContainerPartList { get => containerPartList; set => containerPartList = value; }
        public List<ContainerPartContent> ContainerPartContentList { get => containerPartContentList; set => containerPartContentList = value; }
    }
}
