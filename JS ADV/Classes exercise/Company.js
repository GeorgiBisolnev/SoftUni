class Company{
    
    constructor(){
        this.departments = {};
    }

    addEmployee(name, salary, position, department){

        if ((!name || !salary || !position || !department)) {
            throw new Error("Invalid input!");
          } else if (salary < 0) {
            throw new Error("Invalid input!");
          }
      
          if (!this.departments.hasOwnProperty(department)) {
            this.departments[department] = [];
          }
          this.departments[department].push(Object.assign({}, { name, salary, position }));
          return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment(){

        let bestDepartmentAvgSalary = 0;
        let bestDepartment;
        let bestDepartmentName;

        for (const department in this.departments) {
            this.departments[department].avgSalary = (this.departments[department].employees.reduce((a, b) => a += b.salary, 0) / this.departments[department].employees.length);
            
            if (bestDepartmentAvgSalary < this.departments[department].avgSalary) {
                bestDepartmentAvgSalary = this.departments[department].avgSalary;
                bestDepartment = this.departments[department];
                bestDepartmentName = department;
            }
        }

        bestDepartment.employees.sort((a, b) => b.salary - a.salary || a.name.localeCompare(b.name))

        return `Best Department is: ${bestDepartmentName}\nAverage salary: ${bestDepartmentAvgSalary.toFixed(2)}\n${bestDepartment.employees.map(e => `${e.name} ${e.salary} ${e.position}`).join('\n')}`;
    }
}