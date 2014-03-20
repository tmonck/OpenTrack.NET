namespace OpenTrack.ServiceAPI
{
    public partial class GetClosedRepairOrdersRequest
    {
        public bool ShouldSerializeRepairOrderNumber()
        {
            // fixes issue where if RepairOrderNumber == 0 it serializes with 0 and the call returns zero results
            return this.RepairOrderNumber > 0;
        }
    }

    public partial class GetClosedRepairOrderDetailRequest
    {
        public bool ShouldSerializeRepairOrderNumber()
        {
            // fixes issue where if RepairOrderNumber == 0 it serializes with 0 and the call returns zero results
            return this.RepairOrderNumber > 0;
        }
    }
}