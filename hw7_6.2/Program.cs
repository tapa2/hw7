using System;
using System.Collections;
using System.ComponentModel;

namespace Composite
{
    class Program
    {
        static void Main()
        {
            //Create a tree structure
            FileSystemComponent root = new Directory("root");
            root.Add(new File("File 1"));
            root.Add(new File("File 2"));
            FileSystemComponent comp = new Directory("Directory 1");
            comp.Add(new File("File 1.1"));
            comp.Add(new File("File 1.2"));
            root.Add(comp);
            root.Add(new File("File 3"));
            //Add and remove a leaf
            File leaf = new File("File 4");
            root.Add(leaf);
            root.Remove(leaf);
            //Recursively display tree
            root.Display(1);
            //Wait for user
            Console.Read();
        }
    }
    //"Component"
    abstract class FileSystemComponent
    {
        protected string name;
        //Constructor
        public FileSystemComponent(string name)
        {
            this.name = name;
        }
        public abstract void Add(FileSystemComponent c);
        public abstract void Remove(FileSystemComponent c);
        public abstract void Display(int depth);
    }
    //"Composite"
    class Directory : FileSystemComponent
    {
        private ArrayList children = new ArrayList();
        //Constructor
        public Directory(string name) : base(name) { }
        public override void Add(FileSystemComponent c)
        {
            children.Add(c);
        }
        public override void Remove(FileSystemComponent c)
        {
            children.Remove(c);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            //Recursively display child nodes
            foreach (FileSystemComponent component in children)
            {
                component.Display(depth + 2);
            }
        }
    }
    //"Leaf"
    class File : FileSystemComponent
    {
        //Constructor
        public File(string name) : base(name) { }
        public override void Add(FileSystemComponent c)
        {
            Console.WriteLine("Cannot add to a file");
        }
        public override void Remove(FileSystemComponent c)
        {
            Console.WriteLine("Cannot remove from a file");
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }
}