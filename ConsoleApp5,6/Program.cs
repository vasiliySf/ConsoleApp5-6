using System;

class MainClass
{
    static (string Name, string LastName, int Age, string[] ArrayPets, string[] ArrayColors) EnterUser()
    {
        (string Name, string LastName, int Age, string[] ArrayPets, string[] ArrayColors) User;

        string Name1;
        do
        {
            Console.WriteLine("Введите имя!");
            Name1 = Console.ReadLine();
        }
        while (CheckLetterInString(Name1));

        User.Name = Name1;

        string Name2;
        do
        {
            Console.WriteLine("Введите фамилию!");            
            Name2 = Console.ReadLine();
        }
        while (CheckLetterInString(Name2));
        User.LastName = Name2;

        string age;
        bool Check = false;
        int ResultAge=0;

        while (!Check)
        {
            Console.WriteLine("Введите возраст цифрами!");
            age = Console.ReadLine();
            Check = CheckAge(age, out ResultAge);
        }
        User.Age = ResultAge;

        string answerPets;
        Console.WriteLine("Есть ли у Вас домашние животные (ответ да/нет)?");
        answerPets = Console.ReadLine();

       

        answerPets = answerPets.ToUpper();
        if (answerPets == "ДА")
           {
            int numPet;
            Console.WriteLine("Введите количество домашних животных.");
            numPet = int.Parse(Console.ReadLine());
            User.ArrayPets = CreateFillArrayPets(numPet);
            }
        else
        {
            User.ArrayPets = new string[1] {"нет домашних животных"};
        }

        int numColor;
        Console.WriteLine("Введите количество любимых цветов.");
        numColor = int.Parse(Console.ReadLine());
        User.ArrayColors = CreateFillArrayColor(numColor);

        return User;
    }
    static bool CheckAge(string age, out int ResultAge)
    {

        if (int.TryParse(age, out int intNum))
        {
            if (intNum > 0)
            {
                ResultAge = intNum;
                return true;
            }
            else
            {
                Console.WriteLine("Возраст должен быть больше нуля!");
                ResultAge = -1;
                return false;
            }
        }
        else
        {
            Console.WriteLine("Введите корректный возраст!");
        }

        ResultAge = -1;
        return false;
    }
    static void DisplayUser(string Name, string LastName, int Age, string[] ArrayPets, string[] ArrayColors)
    {
        Console.WriteLine("Имя - {0}",Name);
        Console.WriteLine("Фамилия - {0}", LastName);
        Console.WriteLine("Возраст - {0}", Age);

        foreach(string pet in ArrayPets)
        {
            Console.WriteLine("Домашний питомец - {0}", pet);
        }

        foreach (string color in ArrayColors)
        {
            Console.WriteLine("Цвет - {0}", color);
        }
    }


     
    static string[] CreateFillArrayPets(int Number)
    {
        var result = new string[Number];
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine("Введите имя питомца!");
            result[i] = Console.ReadLine();
        }
        return result;
    }
    static string[] CreateFillArrayColor(int Number)
    {
        var result = new string[Number];
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine("Введите название цвета!");
            result[i] = Console.ReadLine();
        }
        return result;
    }

    static bool CheckLetterInString(string Word)
    {
        for(int i=0; i < Word.Length;i++)
        {
            if (!Char.IsLetter(Word, i ))
            {
                return true;
            }
        }
        return false;
    }

    public static void Main(string[] args)
    {
        var User = EnterUser();
        DisplayUser(User.Name, User.LastName, User.Age, User.ArrayPets, User.ArrayColors);
        Console.ReadKey();
    }
}