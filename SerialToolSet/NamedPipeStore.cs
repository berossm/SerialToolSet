using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialToolSet
{
    public class NamedPipeStore
    {
        public struct Pipe
        {
            public Pipe(string name, bool create)
            {
                this.name = name;
                this.create = create;
            }

            public string name;
            public bool create;
        }

        public List<Pipe> pipe_list;

        public NamedPipeStore()
        {
            pipe_list = new List<Pipe>();
        }

        public int PipeCount()
        {
            return pipe_list.Count;
        }

        public bool HasPipe(string name)
        {
            foreach (Pipe p in pipe_list)
            {
                if (p.name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasCreateFlag(string name)
        {

            return false;
        }

        public void AddPipe(string name, bool create)
        {
            Pipe new_pipe = new Pipe(name, create);
            pipe_list.Add(new_pipe);
        }

        public void DeletePipe(string name)
        {
            foreach(Pipe p in pipe_list)
            {
                if (p.name.Equals(name))
                {
                    pipe_list.Remove(p);
                    break;
                }
            }
        }

        public void ResetPipes()
        {
            pipe_list.Clear();
        }

        public List<string> GetList()
        {
            List<string> tmp_list = new List<string>();
            foreach (Pipe p in pipe_list)
            {
                tmp_list.Add(p.name.ToString());
            }
            return tmp_list;
        }
    }
}
