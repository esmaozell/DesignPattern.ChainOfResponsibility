using DesignPattern.ChainOfResponsibility.DataAcsessLayer;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();

           if(req.Amount <= 100000)
            {
                CustomerProcess customerProcess = new CustomerProcess
                {
                    Amount = req.Amount.ToString(),
                    Name = req.Name,
                    Description = "Para çekme işlemi onaylandı, Müşteriye talep ettiği tutar ödendi",
                    EmployeeName = "Veznadar-Esma Özel"
                };

                context.CustomerProcesses.Add(customerProcess);

                context.SaveChanges();
            }

           else if(NextAprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess
                {
                    Amount = req.Amount.ToString(),
                    Name = req.Name,
                    Description = "Para çekme tutarı veznedarın günlük para çekme limitini aştığı için onaylanmadı",
                    EmployeeName = "Veznadar-Esma Özel"
                };
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextAprover.ProcessRequest(req);
            }
        }
    }
}
