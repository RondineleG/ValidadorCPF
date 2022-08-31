

var listaCPFS = new List<CPFValidator>
{
    new CPFValidator("634.449.030-65"),
    new CPFValidator("021.215.080-84"),
    new CPFValidator("57724756066"),
    new CPFValidator("01782619046"),
    new CPFValidator("222993590955455"),
    new CPFValidator("999999999999"),
    new CPFValidator("dsdsds"),
};

foreach(var cpf in listaCPFS)
{
   Console.WriteLine(cpf.IsValid());
}



