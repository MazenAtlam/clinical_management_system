namespace CCMS.DAL.Enums
{
    public enum MedicalDeviceStatus
    {
        InUse,              // Currently used in a room
        Available,          // In a good conditions to be used, but not used in a room
        NeedMaintenance,    // Does not work, and need maintenance
        UnderMaintenance,   // In the maintenance
        OutOfService,       // Cannot be used any more
        DisposedOf          // Sold or thrown away
    }
}
