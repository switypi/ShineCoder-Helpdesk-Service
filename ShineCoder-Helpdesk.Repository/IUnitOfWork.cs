using Microsoft.EntityFrameworkCore.Storage;
using ShineCoder_Helpdesk.Infrastructure;
using ShineCoder_Helpdesk.Infrastructure.Models;

namespace ShineCoder_Helpdesk.Repository
{
    public interface IUnitOfWork
    {
        GenericRepository<Category> CategorysRepository { get; }
        GenericRepository<SubCategory> SubCategorysRepository { get; }
        GenericRepository<Department> DepartmentRepository { get; }
        GenericRepository<Location> LocationRepository { get; }
        GenericRepository<RequestType> RequestTypeRepository { get; }
        GenericRepository<Ticket_Mode> TicketModeRepository { get; }
        GenericRepository<Ticket_Priorities> TicketPrioritiesRepository { get; }


        GenericRepository<Tickets> TicketRepository { get; }
        GenericRepository<Ticket_Solutions> TicketSolutionsRepository { get; }
        GenericRepository<Ticket_Status> TicketStatusRepository { get; }

        GenericRepository<Product> ProductRepository { get; }
        GenericRepository<Ticket_Impact> ImpactRepository { get; }
        GenericRepository<Ticket_Urgency> UrgencyRepository { get; }


        IDbContextTransaction GetDbTransaction { get; }
        IHelpdeskDbContext GetDbContext { get; }

        void Dispose();
        void Rollback();
        Task<int> SaveAsync();
    }
}