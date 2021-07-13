using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Models.ParametersModule
{
    public class BlockModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string code;
        [DisplayName("Codigo")]
        [Required()]
        [MaxLength(50)]
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private string name;
        [DisplayName("Nombre")]
        [Required()]
        [MaxLength(50)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;
        [DisplayName("Descripcion")]
        [Required()]
        [MaxLength(100)]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        private int projectId;
        [DisplayName("Proyecto del bloque")]
        [Required()]
        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        private ProjectModel project;

        public ProjectModel Project
        {
            get { return project; }
            set { project = value; }
        }

        private IEnumerable<ProjectModel> projectList;

        public IEnumerable<ProjectModel> ProjectList
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