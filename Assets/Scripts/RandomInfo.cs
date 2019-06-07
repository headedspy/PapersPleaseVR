using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInfo : MonoBehaviour {
    private string[] MaleFirstNames = new string[] { "Vladimir", "Dimitri", "Ivan", "Kostya", "Borya", "Boyka", "Egor", "Iosif", "Ioann", "Matvey", "Pasha", "Ruslan", "Pyotr", "Rasputin", "Sasha", "Volodya", "Yaromir", "Alexei", "Anatoly", "Anton", "Boris", "Vasily", "Viktor" };
    private string[] MaleLastNames = new string[] { "Chaykovich", "Agapov", "Abdulov", "Bagrov", "Bogun", "Vasin", "Veselov", "Gorev", "Guryev", "Davidkin", "Dyomin", "Domnin", "Yelchin", "Ivazov", "Istomin", "Komin", "Kazakov", "Ilyushin", "Kostin", "Kapustin", "Komolov", "Lapin" };
    private string[] FemaleFirstNames = new string[] { "Lena", "Alyona", "Angela", "Bogdana", "Diana", "Elizaveta", "Filippa", "Gala", "Galina", "Karina", "Katya", "Lesya", "Luba", "Nadia", "Nata", "Rada", "Polina", "Sasha", "Slava", "Varya", "Verochka", "Verusha", "Yaroslava", "Vladislava" };
    private string[] FemaleLastNames = new string[] { "Idaylova", "Vitaye", "Vistin", "Bukhalo", "Aliyev", "Babikov", "Naychev", "Averin", "Dobrynin", "Yozhin", "Zhabin", "Zaytsev", "Gusin", "Denikin", "Denisov", "Goraya", "Gusin", "Vasin", "Volodin", "Beriya", "Bulygin", "Bukin", "Vanzin", "Vitsin", "Vikhrov" };

    private string[] Countries = new string[]{"Goretsk", "Poleryol", "Kamevgrad", "Yeladovo", "Gelevostok"};

    private string[] CityOne = new string[] { "Arkadak", "Bolotnoe", "Digora", "Balakovo" };
    private string[] CityTwo = new string[] { "Asha", "Borzya", "Borovsk", "Vitsin" };
    private string[] CityThree = new string[] { "Borovichy", "Dankov", "Cherkesk", "Bolkhov" };
    private string[] CityFour = new string[] { "Dobryanka", "Istra", "Izberbash", "Buzuluk" };
    private string[] CityFive = new string[] { "Galich", "Elista", "Dubna", "Chehov" };


    public string GetMaleFirstName(int index) {
        return MaleFirstNames[index];
    }
    public string GetMaleLastName(int index) {
        return MaleLastNames[index];
    }
    public string GetFemaleFirstName(int index) {
        return FemaleFirstNames[index];
    }
    public string GetFemaleLastName(int index) {
        return FemaleLastNames[index];
    }
    public string GetCountries(int index) {
        return Countries[index];
    }

    public string GetCity(string country, int index) {
        if (country == "Goretsk") return CityOne[index];
        else if (country == "Poleryol") return CityTwo[index];
        else if (country == "Kamevgrad") return CityThree[index];
        else if (country == "Yeladovo") return CityFour[index];
        else return CityFive[index];
    }


    public int GetMaleFirstNameSize() {
        return MaleFirstNames.Length;
    }
    public int GetMaleLastNameSize() {
        return MaleLastNames.Length;
    }
    public int GetFemaleFirstNameSize() {
        return FemaleFirstNames.Length;
    }
    public int GetFemaleLastNameSize() {
        return FemaleLastNames.Length;
    }
    public int GetCountriesSize() {
        return Countries.Length;
    }
}
