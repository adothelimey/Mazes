namespace TheGrid
{
    public class GridCell
    {
        public int Xposition { get; private set; }
        private int Column { get { return Xposition; } } //just for some sanity testing

        public int Yposition { get; private set; }
        private int Row { get { return Yposition; } } //just for some sanity testing
        public Dictionary<Direction, GridCell> Neighbours { get; private set; } //reference to this gridcells immediate neighbours        

        public List<GridCell> LinkedNeighbours { get; private set; } //list of Neighbours linked FROM this cell

        public GridCell(int x, int y)
        {
            Xposition = x;
            Yposition = y;

            Neighbours = new Dictionary<Direction, GridCell>();
            LinkedNeighbours = new List<GridCell>();
        }
        /// <summary>
        /// Returns true if a neighbour exists in the specified direction, regardless on if they are connected or not
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool HasNeighbourInDirection(Direction direction)
        {
            return Neighbours.ContainsKey(direction);
        }
        /// <summary>
        /// Returns true if this cell is linked to the cell in specified direction
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool HasLinkedNeighbourInDirection(Direction direction)
        {
            var hasLinkedNeighbourInDirection = false;

            if (Neighbours.ContainsKey(direction))
            {
                var neighbour = Neighbours[direction];
                hasLinkedNeighbourInDirection = LinkedNeighbours.Contains(neighbour);
            }
            return hasLinkedNeighbourInDirection;
        }

        public GridCell? GetNeighbourInDirection(Direction direction)
        {
            GridCell? cell = null;

            if (HasNeighbourInDirection(direction))
            {
                cell = Neighbours[direction];
            }

            return cell;
        }

        public GridCell GetRandomNeighbour()
        {
            var neighbours = Neighbours.Values.ToList();

            var randomNeighbour = neighbours[Random.Shared.Next(0, neighbours.Count)];

            return randomNeighbour;
        }

        public void LinkTo(GridCell cell, bool bidirectional = true)
        {
            LinkedNeighbours.Add(cell);

            if(bidirectional)
                cell.LinkTo(this, false);
        }

        public void UnlinkFrom(GridCell cell, bool bidirectional = true)
        {
            LinkedNeighbours.Remove(cell);

            if (bidirectional)
                cell.UnlinkFrom(this, false);
        }
    }
}