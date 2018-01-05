using Data;
using Domain.ViewModels;
using System.Collections.Generic;

namespace Domain.IServices
{
    public interface IBranchService
    {
        /// <summary>
        /// Get all active branches
        /// </summary>
        IEnumerable<Branch> GetActiveBranches();

        /// <summary>
        /// Get all branches
        /// </summary>
        IEnumerable<Branch> GetAllBranches();

        /// <summary>
        /// Get specific active branch by guid
        /// </summary>
        /// <param name="branchId">Guid of branch</param>
        Branch GetBranchById(string branchId);

        /// <summary>
        /// Add new branch into database
        /// </summary>
        /// <param name="branchVM">Instance of branch view model</param>
        void AddBranch(BranchVM branchVM);

        /// <summary>
        /// Update specific branch name 
        /// </summary>
        /// <param name="branchId">Guid of branch</param>
        /// <param name="name">Name of branch</param>  
        /// <param name="userId">Guid of user</param>
        void UpdateBranchName(string branchId, string name, string userId);

        /// <summary>
        /// Update specific branch address 
        /// </summary>
        /// <param name="branchId">Guid of branch</param>
        /// <param name="address">Address of branch</param>  
        /// <param name="userId">Guid of user</param>
        void UpdateBranchAddress(string branchId, string address , string userId);

        /// <summary>
        /// Update specific branch phone 
        /// </summary>
        /// <param name="branchId">Guid of branch</param>
        /// <param name="phone">Phone of branch</param>  
        /// <param name="userId">Guid of user</param>
        void UpdateBranchPhone(string branchId, string phone, string userId);

        /// <summary>
        /// Update specific branch email
        /// </summary>
        /// <param name="branchId">Guid of branch</param>
        /// <param name="email">Email of branch</param>  
        /// <param name="userId">Guid of user</param>
        void UpdateBranchEmail(string branchId, string email, string userId);

        /// <summary>
        /// Update specific branch code 
        /// </summary>
        /// <param name="branchId">Guid of branch</param>
        /// <param name="branchCode">Code of branch</param>  
        /// <param name="userId">Guid of user</param>
        void UpdateBranchCode(string branchId, string branchCode, string userId);

        /// <summary>
        /// Inactive specific branch 
        /// </summary>
        /// <param name="branchId">Guid of branch</param>
        /// <param name="userId">Guid of user</param>
        void DeleteBranch(string branchId,string userId);

      
       
    }
}
