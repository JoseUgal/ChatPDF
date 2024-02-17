using Microsoft.EntityFrameworkCore;

namespace Codefastly.ChatPDF.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options);