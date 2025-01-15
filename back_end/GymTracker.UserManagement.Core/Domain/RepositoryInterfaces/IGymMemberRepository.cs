namespace GymTracker.UserManagement.Core.Domain.RepositoryInterfaces;

public interface IGymMemberRepository
{
    Task<GymMember?> Get(int gymMemberId);
    Task<GymMember?> GetByUserId(int userId);
    Task<GymMember> Save(GymMember gymMember);
}