using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Models.ParametersModule
{
    public class PropertyModel
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

        private string identification;
        [DisplayName("Identificacion")]
        [Required()]
        [MaxLength(30)]
        public string Identification
        {
            get { return identification; }
            set { identification = value; }
        }

        private int val;
        [DisplayName("Valor")]
        [Required()]
        public int Val
        {
            get { return val; }
            set { val = value; }
        }

        private bool status;
        [DisplayName("Estado")]
        [Required()]
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        private bool removed;
        public bool Removed
        {
            get { return removed; }
            set { removed = value; }
        }

        private int blockId;
        [DisplayName("Propiedad")]
        [Required()]
        public int BlockId
        {
            get { return blockId; }
            set { blockId = value; }
        }

        private BlockModel block;

        public BlockModel Block
        {
            get { return block; }
            set { block = value; }
        }


        private IEnumerable<BlockModel> blockList;

        public IEnumerable<BlockModel> BlockList
        {
            get { return blockList; }
            set { blockList = value; }
        }
    }
}