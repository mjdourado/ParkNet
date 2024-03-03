namespace ParkNet.Data.Repositories;

public class TransactionRepository
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public TransactionRepository(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public void UpdateBalance(Transaction lastTransaction, Transaction currentTransaction)
    {
        if (lastTransaction == null) 
        {
            currentTransaction.FinalBalance = currentTransaction.Amount;
        }
        else if(currentTransaction.Type == TransactionType.Deposit)
        {
            currentTransaction.InitBalance = lastTransaction.FinalBalance;
            currentTransaction.FinalBalance = currentTransaction.InitBalance + currentTransaction.Amount;
            currentTransaction.Balance = currentTransaction.FinalBalance;
        }
        else if(currentTransaction.Type == TransactionType.Withdrawal || currentTransaction.Type == TransactionType.Debit)
        {
            if(lastTransaction.FinalBalance < currentTransaction.Amount)
            {
                throw new InvalidOperationException("Insufficient Balance!");
            }
            currentTransaction.InitBalance = lastTransaction.FinalBalance;
            currentTransaction.FinalBalance = currentTransaction.InitBalance - currentTransaction.Amount;
            currentTransaction.Balance = currentTransaction.FinalBalance;
        }
    }

    public async Task<List<Transaction>> GetAllTransactionsAsync()
    {
        return await _context.Transactions.ToListAsync();
    }

    public async Task<Transaction> GetTransactionByIdAsync(int id)
    {
        return await _context.Transactions.FindAsync(id);
    }

    public async Task <Transaction> AddTransactionAsync(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        return transaction;
    }

    public async Task <Transaction> UpdateTransactionAsync(Transaction transaction)
    {
        _context.Attach(transaction).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return transaction;
    }

    public async Task DeleteTransactionAsync(int id)
    {
        var transaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id);
        _context.Transactions.Remove(transaction);
        await _context.SaveChangesAsync();
    }
}
