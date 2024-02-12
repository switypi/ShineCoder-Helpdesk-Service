using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace ShineCoder_Helpdesk.Infrastructure
{
	public static class ChangeTrackerExtensions
	{
		public static void SetAuditProperties(this ChangeTracker changeTracker, string user)
		{
			changeTracker.DetectChanges();
			IEnumerable<EntityEntry> entities =
				changeTracker
					.Entries()
					.Where(t => t.Entity is BaseEntity &&
					(
						t.State == EntityState.Deleted
						|| t.State == EntityState.Added
						|| t.State == EntityState.Modified
					));

			if (entities.Any())
			{
				DateTime timestamp = DateTime.UtcNow;

				foreach (EntityEntry entry in entities)
				{
					BaseEntity entity = (BaseEntity)entry.Entity;

					switch (entry.State)
					{
						case EntityState.Added:
							entity.CreatedDate = timestamp;
							entity.CreatedBy = user;
						
							entity.Active = true;
							//entity.ModifiedDate = timestamp;
							//entity.UpdatedBy = user;
							break;
						case EntityState.Modified:
							entity.ModifiedDate = timestamp;
							entity.UpdatedBy = user;
							break;
						case EntityState.Deleted:
							entity.ModifiedDate = timestamp;
							entity.UpdatedBy = user;
							entity.Active = false;
							entry.State = EntityState.Modified;
							break;
					}
				}
			}
		}
	}
}
