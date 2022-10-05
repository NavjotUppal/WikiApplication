using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 6.1 Create a separate class file to hold the
// four data items of the Data Structure
// (use the Data Structure Matrix as a guide).
// Use private properties for the fields which must be of type “string”.
// The class file must have separate setters and getters, add an appropriate
// IComparable for the Name attribute. Save the class as “Information.cs”.
namespace WikiApplication
{
    internal class Information: IComparable<Information> 
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

        public int CompareTo(Information comapreName)
        {
           return name.CompareTo(comapreName.name);
        }
    }
}
