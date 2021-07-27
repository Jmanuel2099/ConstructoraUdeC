using System.Collections.Generic;

namespace ConstructoraUdeCController.DTO.ParametersModule
{
    public class BlockDTO
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

        private ProjectDTO project;

        public ProjectDTO Project
        {
            get { return project; }
            set { project = value; }
        }

        private IEnumerable<ProjectDTO> projectList;

        public IEnumerable<ProjectDTO> ProjectList
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
