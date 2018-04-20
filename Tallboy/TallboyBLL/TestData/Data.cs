using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            taskList = new List<Models.Task>() { new Models.Task() { Id= 1, Name="First process", Description="In this task you have to open\n the given container part, and\n scan the QR code inside."} };

            taskElementList = new List<TaskElement>()
            {
                new TaskElement(){Id= 1, Name="1. Subtask" , Description = "Open the red drawer,\nand scan the QRcode!", Order=1 , TaskId= 1, TypeId= 1},
                new TaskElement(){Id=2, Name="2. Subtask", Description = "The first element is ready. Scan the next QRcode, which you will find in the red drawer.",TaskId=1, TypeId=2, Order=2 },
                new TaskElement(){Id=3, Name=" Task done", Description= " Nicely done! You find the two QRcode, so you can play!", Order=3, TaskId= 1}
            };

            typeList = new List<Models.Type>()
            {
                new Models.Type(){Id=1, Name="Rare QRcode", Description="Every QRcode store something.", UUID= "057d09e2-2bc7-4098-8ba0-ad428f3ddf41"},
                new Models.Type(){Id=2, Name="Weird QRcode", Description="Disgusting....", UUID= "464d6419-d6ed-4229-9509-890cd5807f9b" }
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
                new ContainerPartContent(){Id= 2, TypeId=2, Amount=2, ContainerPartId= 17}
            };
        }

        public List<ContainerPartContent> ContainerPartContentList { get => containerPartContentList; set => containerPartContentList = value; }
    }
}
