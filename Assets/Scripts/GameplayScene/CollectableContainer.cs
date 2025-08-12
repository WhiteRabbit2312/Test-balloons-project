namespace TestProject
{
    public class CollectableContainer
    {
        public int StarQuantity { get; private set; }

        public void CollectStar()
        {
            StarQuantity++;
        }
    }
}