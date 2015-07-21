using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_PhonePush
{
    public class Article
    {
        public string id;
        public string content;

        public Article(string id, string content)
        {
            this.id = id;
            this.content = content;
        }
    }
}
