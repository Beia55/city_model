using System;
using System.Collections.Generic;

namespace CityApp
{
    class City
    {
        // This city base on "has-a" relationship
        private int _id;
        private string _name;
        private Mayor _cityMayor;
        private DeputyMayor _cityDeputyMayor;
        private double _area;
        List<People> populationList = new List<People>();
        List<Streets> streetsList = new List<Streets>();
        List<Parks> parksList = new List<Parks>();
        List<MeansOfTransport> meansOfTransportList = new List<MeansOfTransport>();

        public City(int id, string name, Mayor cityMayor, DeputyMayor cityDeputyMayor, double area)
        {
            this._id = id;
            this._name = name;
            this._cityMayor = cityMayor;
            this._cityDeputyMayor = cityDeputyMayor;
            this._area = area;
        }
        public void addPeople(People p)
        {
            populationList.Add(p);
        }
        public void removePerson(People p) {
            populationList.Remove(p);
        }
        public string displayPopulationList()
        {
            string resultList = "The populaton list from this city is: ";
            foreach (People p in populationList)
            {
                resultList += "\n\t ->" + p.Name;
            }
            return resultList;
        }
        public void addPark(Parks p)
        {
            parksList.Add(p);
        }
        public void removePark(Parks p)
        {
            parksList.Remove(p);
        }
        public string displayParkList()
        {
            string resultList = "Parks list from this city is: ";
            foreach (Parks p in parksList)
            {
                resultList += "\n\t ->" + p.Name;
            }
            return resultList;
        }
        public void addMeansOfTransport(MeansOfTransport m)
        {
            meansOfTransportList.Add(m);
        }
        public void removeMeansOfTransport(MeansOfTransport m)
        {
            meansOfTransportList.Remove(m);
        }
        public string displayMeansOfTransportList()
        {
            string resultList = "Means of transport list from this city is: ";
            foreach (MeansOfTransport m in meansOfTransportList)
            {

                if (m is Cars) { resultList += "\n\t -> " + "Car: " + (m as Cars).RegistrationNo; }
                else if (m is Bus) { resultList += "\n\t -> " + "Bus: " + (m as Bus).RegistrationNo; }
                else if (m is Tram) { resultList += "\n\t -> " + "Tram: " + (m as Tram).RegistrationNo; }
                else { Console.WriteLine("Error! This is not a mean of transport !"); }
            }
            return resultList;
        }
        public void addStreet(Streets s)
        {
            streetsList.Add(s);
        }
        public void removeStreet(Streets s)
        {
            streetsList.Remove(s);
        }
        public string displayStreetsList()
        {
            string resultList = "The streets list from this city is: ";
            int i = 1;
            foreach (Streets s in streetsList)
            {
                resultList += "\n\t "+i+". "+s.Name +"Street ->" +". \n"+ s.displayList();
                i++;
            }
            return resultList;
        }
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public double Area { get => _area; set => _area = value; }
        public Mayor CityMayor { get => _cityMayor; set => _cityMayor = value; }
        public DeputyMayor CityDeputyMayor { get => _cityDeputyMayor; set => _cityDeputyMayor = value; }

        public override string ToString()
        {
            return "City: "+Name+" have the ID: "+Id+".\n The mayor is: "+CityMayor.Name+" and the deputy mayor is: "+CityDeputyMayor.Name+ ".\n The surface is "+Area+" mXm";
        }
    }

    abstract class People
    {
        // The population of the city is based on a "is-a" relationship and Polymorphism
        private string _name, _gender;
        private int _CNP, _age;
        public People(string name, int CNP, string gender, int age)
        {
            this._name = name;
            this._CNP = CNP;
            this._age = age;
            if (gender == "Male" || gender == "Female")
            {
                this._gender = gender;
            }
            else
            {
                Console.WriteLine("Error! You have to choose between 'Male' and 'Female'!");
            }
        }
        public string Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }
        public int CNP { get => _CNP; set => _CNP = value; }
        public string Gender { get => _gender; set => _gender = value; }

        public abstract override string ToString();
    }

    class Unemployed : People
    {
        private int _id_Unemployed;
        public Unemployed(string name, int CNP, string gender, int age, int id_Unemployed) : base(name, CNP, gender, age)
        {
            this._id_Unemployed = id_Unemployed;
        }
        public int Id_Unemployed { get => _id_Unemployed; set => _id_Unemployed = value; }
        public override string ToString() {
            string gender = "";
            if (this.Gender == "Male") {
                gender = "Man";
            }
            else if (this.Gender == "Female") {
                gender = "Women";
            } else {
                Console.WriteLine("Gender Error! ");
            }
            return gender+" -> Name: "+Name+", \n\t -> CNP: "+CNP+", \n\t -> Age: "+ Age +", \n\t -> Unemployed Id: "+Id_Unemployed;
        }
    }

    abstract class Employed : People
    {
        private string _company;
        private int _seniority;
        private double _salary;
        public Employed(string name, int CNP, string gender, int age, string company, int seniority, double salary) : base(name, CNP, gender, age)
        {
            this._company = company;
            this._seniority = seniority;
            this._salary = salary;
        }
        public abstract double salaryCalculation();
        public string Company { get => _company; set => _company = value; }
        public int Seniority { get => _seniority; set => _seniority = value; }
        public double Salary { get => _salary; set => _salary = value; }
        public override string ToString()
        {
            string gender = "";
            if (this.Gender == "Male")
            {
                gender = "Man";
            }
            else if (this.Gender == "Female")
            {
                gender = "Women";
            }
            else
            {
                Console.WriteLine("Gender Error! ");
            }
            return gender + " -> Name: " + Name + ", \n\t -> CNP: " + CNP + ", \n\t -> Age: " + Age + ", \n\t -> Work at: "+Company+", \n\t -> Seniority: "+Seniority+", \n\t -> Salary: " +Salary;
        }
    }

    class Mayor : Employed
    {
        private int _noOfMandats;
        public Mayor(string name, int CNP, string gender, int age, string company, int seniority, double salary, int noOfMandats) : base(name, CNP, gender, age, company, seniority, salary)
        {
            if (_noOfMandats <= 7)
            {
                this._noOfMandats = noOfMandats;
            }
            else {
                Console.WriteLine("The maxim standard number of years for mandats is 7!");
            }
        }
        public override double salaryCalculation()
        {
            double bonus = 0;
            if (_noOfMandats >= 5)
            {
                bonus = 7 / 100 * this.Salary;
            }
            else
            {
                bonus = 0;
            }
            return this.Salary + bonus;
        }
        public int NoOfMandats { get => _noOfMandats; set => _noOfMandats = value; }
        public String lastSupportedProject(string project) {
            return project;
        }
        public override string ToString() {
            return "Mayor: "+base.ToString() + ", \n\t -> Number of mandats: "+ NoOfMandats;
        }
    }

    class DeputyMayor : Employed
    {
        private int _noOfMandats;
        public DeputyMayor(string name, int CNP, string gender, int age, string company, int seniority, double salary, int noOfMandats) : base(name, CNP, gender, age, company, seniority, salary)
        {
            if (_noOfMandats <= 7)
            {
                this._noOfMandats = noOfMandats;
            }
            else
            {
                Console.WriteLine("The maxim standard number of years for mandats is 7!");
            }
        }
        public override double salaryCalculation()
        {
            double bonus = 0;
            if (_noOfMandats >= 5)
            {
                bonus = 5 / 100 * this.Salary;
            }
            else
            {
                bonus = 0;
            }
            return this.Salary + bonus;
        }
        public int NoOfMandats { get => _noOfMandats; set => _noOfMandats = value; }
        public override string ToString()
        {
            return "Deputy Mayor: "+base.ToString() + ", \n\t -> Number of mandats: " + NoOfMandats;
        }
    }

    class OrdinaryEmployees : Employed
    {
        private string _actualJob;
        private int _extraHours;
        private const int MoneyPerHour = 20;
        public OrdinaryEmployees(string name, int CNP, string gender, int age, string company, int seniority, double salary, string actualJob, int extraHours) : base(name, CNP, gender, age, company, seniority, salary)
        {
            this._actualJob = actualJob;
            this._extraHours = extraHours;
        }
        public override double salaryCalculation()
        {
            double bonus = _extraHours * MoneyPerHour;
            return this.Salary + bonus;
        }
        public string ActualJob { get => _actualJob; set => _actualJob = value; }
        public int ExtraHours { get => _extraHours; set => _extraHours = value; }
        public override string ToString()
        {
            return base.ToString() + ", \n\t -> Actual job " + ActualJob + ", \n\t -> Extra worked days: "+ExtraHours;
        }
    }

    public enum TypesBuildings{Residential, Commercial, Industrial, Infrastructure, Agricultural, Specialty,}
    
    abstract class Buildings 
    {
        // The buildings from the city are based on a "is-a" relationship and Polymorphism
        private int _noAdress;
        private Streets _strAdress;
        private double _area;
        private TypesBuildings _type;
        public Buildings(Streets strAdress, int noAdress, double area, TypesBuildings type)
        {
            this._noAdress = noAdress;
            this._strAdress = strAdress;
            this._area = area;
            this._type = type;
        }
        public int NoAdress { get => _noAdress; set => _noAdress = value; }
        public Streets StrAdress { get => _strAdress; set => _strAdress = value; }
        public double Area { get => _area; set => _area = value; }
        public TypesBuildings Type { get => _type; set => _type = value; }
        public override string ToString()
        {
            return "\t --- Adress: Str "+StrAdress + ", No "+NoAdress+",\n\t --- Area: "+Area+",\n\t --- Type: "+Type;
        }
    }

    class Shops : Buildings
    {
        private string _name;
        public Shops( string name, Streets strAdress, int noAdress, double area, TypesBuildings type) : base(strAdress, noAdress, area, type)
        {
            this._name = name;
        }
        public string Name { get => _name; set => _name = value; }
        public override string ToString()
        {
            return "Shop: "+Name+",\n"+base.ToString()+"\n";
        }
    }

    class CityHall : Buildings
    {
        private String _uniqueHallId;
        public CityHall(string uniqueHallId, Streets strAdress, int noAdress, double area, TypesBuildings type) : base(strAdress, noAdress, area, type)
        {
            this._uniqueHallId = uniqueHallId;
        }
        public string UniqueHallId { get => _uniqueHallId; set => _uniqueHallId = value; }
        public override string ToString()
        {
            return "City Hall \n\t --- Id: " +UniqueHallId+ ",\n"+ base.ToString()+"\n";
        }
    }

    enum GravityLevels { L_1, L_2, L_3, L_4 }

    class Hospitals : Buildings
    {
        private string _name;
        private GravityLevels _severityLevel;
        public Hospitals( string name, GravityLevels severityLevel, Streets strAdress, int noAdress, double area, TypesBuildings type) : base(strAdress, noAdress, area, type)
        {
            this._name = name;
            this._severityLevel = severityLevel;
        }
        public string Name { get => _name; set => _name = value; }
        public GravityLevels SevetityLevel { get => _severityLevel; set => _severityLevel = value; }
        public override string ToString()
        {
            return "Hospital: " + Name+ ",\n\t --- Severity Level" +SevetityLevel+ ",\n" + base.ToString()+"\n";
        }
    }

    public enum CultTypes { Eastern_Orthodoxy, Roman_Catholic, Greek_Catholic, Protestantism, Islam, Judaism }
    class Churses : Buildings
    {
        private string _name;
        private CultTypes _cultType;
        private int _members;
        public Churses( string name, CultTypes cultType, Streets strAdress, int noAdress, double area, TypesBuildings type, int members) : base(strAdress, noAdress, area, type)
        {
            this._name = name;
            this._cultType = cultType;
            this._members = members;
        }
        public string Name { get => _name; set => _name = value; }
        public CultTypes CultureType { get => _cultType; set => _cultType = value; }
        public int Members { get => _members; set => _members = value; }
        public override string ToString()
        {
            return "Church: " + Name + ", \n\t --- Cult: " + CultureType+ ", \n\t --- Number of members: "+Members+", \n"+ base.ToString()+"\n";
        }
    }

    class Museum : Buildings
    {
        private string _name;
        private double _entranceFee;
        public Museum( string name, double entranceFee, Streets strAdress, int noAdress, double area, TypesBuildings type) : base(strAdress, noAdress, area, type)
        {
            this._name = name;
            this._entranceFee = entranceFee;
        }
        public string Name { get => _name; set => _name = value; }
        public double EntranceFee { get => _entranceFee; set => _entranceFee = value; }
        public override string ToString()
        {
            return "Museum: " + Name + ", \n\t Fee for Entrance: " + EntranceFee+ ", \n" + base.ToString()+"\n";
        }
    }

    abstract class EducationalInstitutions : Buildings
    {
        private string _name;
        private int _educationId;
        public EducationalInstitutions( string name, Streets strAdress, int noAdress, double area, TypesBuildings type, int educationId) : base(strAdress, noAdress, area, type)
        {
            this._name = name;
            this._educationId = educationId;
        }
        public abstract string theVision();
        public string Name{ get => _name; set => _name= value; }
        public int EducationId { get => _educationId; set => _educationId = value; }
        public override string ToString()
        {
            return  Name + ", \n" + base.ToString() + ", \n\t --- Education Id: "+ EducationId;
        }
    }

    class Universities : EducationalInstitutions
    {
        private bool _accreditation;
        public Universities( string name, bool accreditation, Streets strAdress, int noAdress, double area, TypesBuildings type, int educationId) : base( name, strAdress, noAdress, area, type, educationId)
        {
            this._accreditation = accreditation;
        }
        public override string theVision()
        {
            return "Our main vision is to prepare you for your future career !";
        }
        public bool Accreditation { get => _accreditation; set => _accreditation = value; }
        public override string ToString()
        {
            return "University: "+base.ToString() + ", \n\t --- Accreditation: " +Accreditation + "\n";
        }
    }

    class HighSchools : EducationalInstitutions
    {
        private string _specialization;
        public HighSchools(string name, Streets strAdress, int noAdress, string specialization, double area, TypesBuildings type, int educationId) : base( name, strAdress, noAdress, area, type, educationId)
        {
            this._specialization = specialization;
        }
        public override string theVision()
        {
            return "Our main vision is to help you choose the field in which you want to work in future!";
        }
        public string Specialization { get => _specialization; set => _specialization= value; }
        public override string ToString()
        {
            return "HighSchool: "+base.ToString() + ",\n\t --- Specialization: " + Specialization +"\n";
        }
    }

    class SecondarySchool : EducationalInstitutions
    {
        private string _extracurricularActivities;
        public SecondarySchool( string name, Streets strAdress, int noAdress, double area, TypesBuildings type, int educationId, string extracurricularActivities) : base( name, strAdress, noAdress, area, type, educationId)
        {
            this._extracurricularActivities = extracurricularActivities;
        }
        public override string theVision()
        {
            return "Our main vision is to lay the foundations that every human being must have!";
        }
        public string ExtracurricularSctivities { get => _extracurricularActivities; set => _extracurricularActivities = value; }
        public override string ToString()
        {
            return "Secondary School: "+base.ToString() + ",\n\t --- Extracurricular activities: " + ExtracurricularSctivities+"\n";
        }
    }

    class Kindergartens : EducationalInstitutions
    {
        public Kindergartens( string name, Streets strAdress, int noAdress, double area, TypesBuildings type, int educationId) : base( name, strAdress, noAdress, area, type, educationId) { }
        public override string theVision()
        {
            return "Our main goal is to help you integrate into a community!";
        }
        public bool isThereAPlayground(bool _is)
        {
            return _is;
        }
        public override string ToString()
        {
            return "Kindergarden: " + base.ToString()+"\n";
        }
    }

    class BlocksOfFlats : Buildings
    {
        private int _noOfFlats;
        public BlocksOfFlats(Streets strAdress, int noAdress, double area, TypesBuildings type, int noOfFlats) : base(strAdress, noAdress, area, type)
        {
            this._noOfFlats = noOfFlats;
        }
        private int NoOfFlats { get => _noOfFlats; set => _noOfFlats = value; }
        public override string ToString()
        {
            return "Block of flats: \n\t --- Has : " + NoOfFlats+ "flats, \n " + base.ToString()+"\n";
        }
    }
    class Houses : Buildings
    {
        private People _owner;
        public Houses(People owner, Streets strAdress, int noAdress, double area, TypesBuildings type) : base(strAdress, noAdress, area, type)
        {
            this._owner = owner;
        }
        private People Owner { get => _owner; set => _owner = value; }
        public override string ToString()
        {
            return "House: \n\t --- House's owner: " + Owner+ ", \n" + base.ToString()+"\n";
        }
    }
    enum StreetTypes { LocalUseStreets, CollectorStreets, ConnectingStreets, Highways }

    class Streets
    {
        // The population of the city is based on a "has-a" relationship 
        List<Buildings> buildingsList = new List<Buildings>();
        private string _name;
        private  StreetTypes _streetType;
        public Streets(string name, StreetTypes streetType)
        {
            this._name = name;
            this._streetType = streetType;
        }
        public string Name { get => _name; set => _name = value; }
        public override string ToString()
        {
            return "Street name: "+ Name;
        }

        public void addBuilding(Buildings b) {
            if (b.StrAdress == this)
            {
                buildingsList.Add(b);
            }
            else {
                Console.WriteLine("Sory! This building doesn't belong to this street !");
            }
        }
        public void removeBuilding(Buildings b) {
            buildingsList.Remove(b);
        }
        public string displayList() {
            string resultList = "\t The list with the buildings from this street is:";
            foreach(Buildings b in buildingsList)
            {
                resultList +="\n\t ->"+ b;
            }
            return resultList;
        }
    }

    class Parks
    {
        private string _name;
        private double _area;
        public Parks(string name, double area)
        {
            this._name = name;
            this._area = area;
        }
        public string Name { get => _name; set => _name = value; }
        public double Area { get => _area; set => _area = value; }
        public override string ToString()
        {
            return "Park name: " + Name+ " - Area: "+Area;
        }
    }

    abstract class MeansOfTransport
    {
        // The Means of transport from the city are based on a "is-a" relationship and Polymorphism
        private string _registrationNo;
        public MeansOfTransport(string registrationNo)
        {
            this._registrationNo = registrationNo;
        }
        public abstract string showFillProcess(string fillProces);
        public string RegistrationNo { get => _registrationNo; set => _registrationNo = value; }
        public abstract override string ToString();
    }
    class Cars : MeansOfTransport
    {
        private People _owner;
        public Cars(string registrationNo, People owner) : base(registrationNo)
        {
            this._owner = owner;
        }
        public override string showFillProcess(string fillProces)
        {
            return fillProces;
        }
        public People Owner { get => _owner; set => _owner = value; }
        public override string ToString()
        {
            return " The car with registration number: " + base.RegistrationNo + " has the owner: \n"+Owner.Name;
        }
    }
    class Bus : MeansOfTransport
    {
        private int _workHours;
        public Bus(string registrationNo, int workHours) : base(registrationNo)
        {
            this._workHours = workHours;
        }
        public override string showFillProcess(string fillProces)
        {
            return fillProces;
        }
        public int WorkHours { get => _workHours; set => _workHours = value; }
        public override string ToString()
        {
            return " The bus with registration number: " + base.RegistrationNo + " works: \n" + WorkHours+" on day";
        }
    }

    class Tram : MeansOfTransport
    {
        private int _workHours;
        public Tram(string registrationNo, int workHours) : base(registrationNo)
        {
            this._workHours = workHours;
        }
        public override string showFillProcess(string fillProces)
        {
            return fillProces;
        }
        public int WorkHours
        {
            get => _workHours; set => _workHours = value;
        }
        public override string ToString()
        {
            return " The tram with registration number: " + base.RegistrationNo + " works: \n" + WorkHours + " on day";
        }
    }

    class TestCityApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello this is a city model ! Write 'Yes' if you want to see it and 'No' if you don't want to see it! :)");
            string answer = Console.ReadLine();
            Console.WriteLine($"Your answer was: '{answer}'!");

            if (answer == "No")
            {
                Console.WriteLine("Sorry! Because you said 'No', you cann't see the model ! :(");
            }
            else {
                Console.WriteLine("Yeyy !!! It's time ! This is the city model: ");
                Console.WriteLine("\t --> Important: Remember that all information for this city plan is false! \n");

                Streets street_roses = new Streets("Roses", StreetTypes.LocalUseStreets);
                Streets street_central = new Streets("Central", StreetTypes.LocalUseStreets);
                Streets street_university = new Streets("University's", StreetTypes.CollectorStreets);

                People unemployed_01 = new Unemployed("Levi", 20526347, "Male", 40, 534724);
                People unemployed_02 = new Unemployed("Carl", 10642342, "Male", 23, 346723);
                People unemployed_03 = new Unemployed("Serafina", 10573985, "Female", 43, 693486);
                People ordinaryEmployees_01 = new OrdinaryEmployees("Angi", 10827645, "Female", 34, "Oracle", 13, 370.00, "Java developer", 25);
                People ordinaryEmployees_02 = new OrdinaryEmployees("Ovi", 20678364, "Male", 24, "Optimedia", 7, 300.00, "Consultant", 30);

                CityHall hall = new CityHall("ORD-2355",street_central, 55, 600, TypesBuildings.Specialty);
                Churses church = new Churses("Betel", CultTypes.Protestantism,street_roses, 13,500,TypesBuildings.Specialty, 700);
                Shops shop = new Shops("Lidl",street_university,33, 600, TypesBuildings.Commercial);
                Museum museum = new Museum("Oradea's Museum", 25, street_central,40,800,TypesBuildings.Infrastructure);
                Universities university = new Universities("Agora",true,street_roses,20, 750, TypesBuildings.Specialty,773570);
                Buildings kindergartens = new Kindergartens("Aleodor",street_university,55, 450, TypesBuildings.Specialty,352560);
                Buildings hospital = new Hospitals("Pelican",GravityLevels.L_2,street_central,11,1000, TypesBuildings.Specialty);
                Buildings blockOfFlat_01 = new BlocksOfFlats(street_university,73,900, TypesBuildings.Industrial,15);
                Buildings blockOfFlat_02 = new BlocksOfFlats(street_roses,23,950, TypesBuildings.Residential,20);
                Buildings house = new Houses(unemployed_01,street_roses,21,300, TypesBuildings.Residential);
                Buildings farm = new Houses(ordinaryEmployees_01,street_central,48,550, TypesBuildings.Agricultural);

                Mayor mayor = new Mayor("Timi", 20304050, "Male", 37, hall.UniqueHallId, 15, 350.00, 3);
                DeputyMayor deputyMayor = new DeputyMayor("Lara", 10234635, "Female", 40, hall.UniqueHallId,12, 300.00, 2);

                MeansOfTransport car = new Cars("BH-101-FAF",unemployed_02);
                MeansOfTransport bus = new Bus ("BH-10-XPB",13);
                MeansOfTransport tram = new Tram("Bh-02798",12);

                Parks park_snowdrop = new Parks("Snowdrop's place", 800);
                Parks park_december = new Parks("December 1st", 1000);

                street_roses.addBuilding(church);
                street_roses.addBuilding(university);
                street_roses.addBuilding(blockOfFlat_02);
                street_roses.addBuilding(house);

                street_central.addBuilding(hall);
                street_central.addBuilding(museum);
                street_central.addBuilding(farm);
                street_central.addBuilding(hospital);

                street_university.addBuilding(shop);
                street_university.addBuilding(kindergartens);
                street_university.addBuilding(blockOfFlat_01);

                City city = new City(238579015, "Oradea", mayor, deputyMayor, 115.60);

                    city.addPeople(unemployed_02);
                    city.addPeople(ordinaryEmployees_02);
                    city.addPeople(unemployed_01);
                    city.addPeople(unemployed_03);

                    city.addPark(park_december);
                    city.addPark(park_snowdrop);

                    city.addMeansOfTransport(car);
                    city.addMeansOfTransport(bus);
                    city.addMeansOfTransport(tram);

                    city.addStreet(street_roses);
                    city.addStreet(street_central);
                    city.addStreet(street_university);

                Console.WriteLine(city.displayPopulationList()+"\n");
                Console.WriteLine(city.displayMeansOfTransportList() + "\n");
                Console.WriteLine(city.displayParkList() + "\n");
                Console.WriteLine(city.displayStreetsList() + "\n");
            }
        }
    }
}
