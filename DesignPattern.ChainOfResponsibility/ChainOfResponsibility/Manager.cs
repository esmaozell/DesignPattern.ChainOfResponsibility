using DesignPattern.ChainOfResponsibility.DataAcsessLayer;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class Manager : Employee
    {
       Context context = new Context();
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            if (req.Amount <= 250000)
            {
                CustomerProcess customerProcess = new CustomerProcess
                {
                    Amount = req.Amount.ToString(),
                    Name = req.Name,
                    EmployeeName = "Şube Müdürü  - Esma Özel",
                    Description = "Para çekme işlemi onaylandı, müşteriye talep ettiği tutar ödendi",

                };

                context.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextAprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess
                {
                    Amount = req.Amount.ToString(),
                    Name = req.Name,
                    Description = "Para çekme tutarı şube müdürünün günlük para çekme limitini aştığı için onaylanmadı",
                    EmployeeName = "Şube Müdürü - Esma Özel"
                };
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextAprover.ProcessRequest(req);
            }
        }
    }
}
