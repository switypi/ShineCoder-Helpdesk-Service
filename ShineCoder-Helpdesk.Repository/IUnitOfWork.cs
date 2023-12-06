using Microsoft.EntityFrameworkCore.Storage;
using ShineCoder_Helpdesk.Infrastructure.Models;

namespace ShineCoder_Helpdesk.Repository
{
	public interface IUnitOfWork
	{
		GenericRepository<Ticket_Issues> TicketIssuesRepository { get; }
		GenericRepository<Ticket_Priorities> TicketPrioritiesRepository { get; }
		GenericRepository<Tickets> TicketRepository { get; }
		GenericRepository<Ticket_Solutions> TicketSolutionsRepository { get; }
		GenericRepository<Ticket_Status> TicketStatusRepository { get; }
		IDbContextTransaction GetDbTransaction { get; }
		
		void Dispose();
		void Rollback();
		void Save();
	}
}