using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCModel.DbModel.ParametersModule
{
    public class BlockDbModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        private int projectId;

        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        private ProjectDbModel project;

        public ProjectDbModel Project
        {
            get { return project; }
            set { project = value; }
        }

        private IEnumerable<ProjectDbModel> projectList;

        public IEnumerable<ProjectDbModel> ProjectList
        {
            get { return projectList; }
            set { projectList = value; }
        }

        private bool removed;

        public bool Removed
        {
            get { return removed; }
            set { removed = value; }
        }
    }
}
