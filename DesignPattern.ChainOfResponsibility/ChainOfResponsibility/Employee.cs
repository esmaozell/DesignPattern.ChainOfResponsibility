using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public abstract class Employee
    {
        protected Employee NextAprover;

        public void SetNextAprover(Employee superVisor)
        {
            this.NextAprover = superVisor;
        }

        public abstract void ProcessRequest(CustomerProcessViewModel req);
    }
}
