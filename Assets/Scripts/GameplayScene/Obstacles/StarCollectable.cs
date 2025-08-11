namespace TestProject
{
    public class StarCollectable : BaseCollectableItem
    {
        public override void OnCollect()
        {
            if (CollectableContainer != null)
            {
                CollectableContainer.CollectStar();
            }
            Destroy(gameObject);
        }
    }
}