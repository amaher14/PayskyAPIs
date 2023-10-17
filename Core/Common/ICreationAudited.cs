
namespace Core
{
    public interface ICreationAudited
    {
        //
        // Summary:
        //     Creation time of this entity.
        DateTime CreatedAt { get; set; }
        //
        // Summary:
        //     Id of the creator user of this entity.
        Guid? CreatedBy { get; set; }
    }
}
