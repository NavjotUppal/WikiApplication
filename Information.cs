using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiApplication
{
    internal class Information
    {
        private string name;
        private string category;
        private string structure;
        private string definition;
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getCategory()
        {
            return category;
        }
        public void setCategory(string category)
        {
            this.category = category;
        }
        public string getStructure()
        {
            return structure;
        }
        public void setStructure(string structure)
        {
            this.structure = structure;
        }
        public string getDefinition()
        {
            return definition;
        }
        public void setDefintion(string definition)
        {
            this.definition = definition;
        }
    }
}
