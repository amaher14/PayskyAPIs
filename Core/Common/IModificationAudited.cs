namespace Core;

public interface IModificationAudited
{
    //
    // Summary:
    //     Used to mark an Entity as 'Deleted'.
    bool IsDeleted { get; set; }
    //
    // Summary:
    //     The last modified time for this entity.
    DateTime? LastModificationAt { get; set; }
    //
    // Summary:
    //     Last modifier user for this entity.
    Guid? LastModificationBy { get; set; }
}
