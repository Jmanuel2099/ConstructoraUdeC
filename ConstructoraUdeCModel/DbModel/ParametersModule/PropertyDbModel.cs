using System.Collections.Generic;

namespace ConstructoraUdeCModel.DbModel.ParametersModule
{
    public class PropertyDbModel
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

        private string identification;

        public string Identification
        {
            get { return identification; }
            set { identification = value; }
        }

        private int val;

        public int Val
        {
            get { return val; }
            set { val = value; }
        }

        private bool status;

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

        public int BlockId
        {
            get { return blockId; }
            set { blockId = value; }
        }

        private BlockDbModel block;

        public BlockDbModel Block
        {
            get { return block; }
            set { block = value; }
        }

        private IEnumerable<BlockDbModel> blockList;

        public IEnumerable<BlockDbModel> BlockList
        {
            get { return blockList; }
            set { blockList = value; }
        }
    }
}
