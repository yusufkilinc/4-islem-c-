using System.Transactions;

List<Todo> todoList = new List<Todo>();
string select, title, durum;
int id;
while (true)
{
    Console.WriteLine(
        "Yapmak istediğiniz işlem\n[0] Çıkış \n[1] Listele\n[2] Ekle\n[3] Düzenle\n[4] Sil"
    );
    select = Console.ReadLine()!;
    switch (select)
    {
        case "0":
            Console.WriteLine("Güle güle!!");
            Environment.Exit(0);
            break;
        case "1":
            listele();
            continue;
        case "2":
            ekle();
            continue;
        case "3":
            guncelle();
            continue;
        case "4":
            sil();
            continue;
        default:
            Console.WriteLine("Lütfen 0-4 arasında bir değer girin:");
            continue;
    }
}

void listele()
{
    if (todoList.Count > 0)
    {
        Console.WriteLine("ID\tBaşlık\t\tDurum");
        foreach (var todo in todoList)
        {
            Console.WriteLine("{0}\t{1}\t\t{2}", todo.id, todo.title, todo.isComplated);
        }
    }
    else
    {
        Console.WriteLine("Kayıt Bulunamadı!!");
    }
}
void ekle()
{
    Console.Write("Başlık Girin:");
    title = Console.ReadLine()!;
    if (todoList.Count() > 0)
    {
        id = todoList.Last().id + 1;
    }
    else
    {
        id = 1;
    }
    Todo todo = new Todo(id, title, false);
    todoList.Add(todo);
    Console.WriteLine("Kayıt Başarıyla Eklendi");
}
void sil()
{
    listele();
    Console.Write("Silmek istediğiniz id:");
    id = int.Parse(Console.ReadLine()!);

    Todo todo = todoList.Find(x => x.id == id)!;
    if (todo != null)
    {
        todoList.Remove(todo);
        Console.WriteLine("Kayıt Silindi!");
    }
    else
    {
        Console.WriteLine("Girmiş olduğunuz Id'ye sahip kayıt bulunamadı!");
        sil();
    }
}
void guncelle()
{
    listele();
    Console.Write("Güncellemek istediğiniz Id:");
    id = int.Parse(Console.ReadLine()!);

    Todo todo = todoList.Find(x => x.id == id)!;
    if (todo != null)
    {
        Console.WriteLine("Yeni Başlık:");
        title = Console.ReadLine()!;

        Console.WriteLine("Görev tamamlamdı mı? (E/H):");
        durum = Console.ReadLine()!.ToUpper();
        if (durum == "E")
        {
            todo.isComplated = true;
        }
        else
        {
            todo.isComplated = false;
        }
        todo.title = title;
        Console.WriteLine("Kayıt Güncellendi!!");
    }
    else
    {
        Console.WriteLine("Girmiş olduğunuz Id'ye sahip kayıt bulunamadı!");
        guncelle();
    }
}
