# C# Test Task
# GMapWinForm
**Задание 1**

На языке C# необходимо разработать приложение Windows Forms (**ОБЯЗАТЕЛЬНО .NET Framework**), которое выполняет требования:

- На главной форме содержит карту из библиотеки GMap.NET;
- Загружает из базы данных Microsoft SQL Server географические координаты условных единиц техники;
- Отображает их на карте в виде маркеров.
- Так же необходимо реализовать перемещение маркеров с помощью мыши (Drag&Drop, то есть нажать на маркер и перенести в другую точку карты);
- Сохранение новых координат в базу данных, чтобы после перезапуска приложения маркеры были расположены так же, как и до закрытия приложения.

**При работе с базой данных нельзя пользоваться никакими фреймворками (EntityFramework и т.д.), необходимо использовать T-SQL.**

# Пример работы

<p align="center">
  <img src="https://github.com/I-D4C-I/GMapWinFormTestTask/assets/98944264/9d719399-9dc2-49fb-8ed0-b64c5a4c2101" />
  <br>
  <img src="https://github.com/I-D4C-I/GMapWinFormTestTask/assets/98944264/4cb8deec-74a0-4608-8831-a2a6b1059205" />
  <br>
  <img src="https://github.com/I-D4C-I/GMapWinFormTestTask/assets/98944264/6c6c2c94-bf33-49d6-b774-be94e5457380" />
</p>

**Задания 2 и 3** выполняются на ЯП C#. Необходимо создать проект в [.NET Fiddle](https://dotnetfiddle.net/), [CodingGround](http://www.tutorialspoint.com/compile_csharp_online.php) или другом онлайн-инструменте.

**Задание 2**

1. Написать процедуры обхода **бинарного дерева поиска** в глубину (preorder) и в ширину. **Только этих два обхода необходимо реализовать, никаких дополнительных видов обхода не нужно.**
2. Организовать функцию вставки значения в бинарное дерево

[BiSearchTree | C# Online Compiler | .NET Fiddle](https://dotnetfiddle.net/PKZynB)

**Задание 3**

Для типа «односвязный неизменяемый список», определенного как

```
  Class ListNode<T> {
      Public readonly T Value;
      Public readonly ListNode<T> Next;
      …
  }
```

Написать две функции: замены элемента в списке и объединения двух списков.

[Immutable List | C# Online Compiler | .NET Fiddle](https://dotnetfiddle.net/WsD5uw)
