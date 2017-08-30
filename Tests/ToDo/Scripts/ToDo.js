var baseUri='http://ToDo.KpXX.Ru/api/';
// baseUri='http://localhost:17814/api/';
var todoUri=baseUri+'ToDo/'
var infoUri=baseUri+'Info/'

function NewTask(name)
{
    this.TaskId=0;
    this.Name=name;
    this.Done=false;
}

//
// Обновить информацию в теле таблицы
//
function updateInfo()
{
    tbody=$('#ForShow').children();
    //
    // Две последних строки - специальные, их не трогаем
    //
    for (var i=0; i<tbody.length-2; i++)
    {
        if   (tbody[i].firstChild.firstChild.checked) $(tbody[i].children[1]).addClass("checked");
        else                                          $(tbody[i].children[1]).removeClass("checked");

    }

    //
    // Получить с сервера информацию о количестве задач - в работе и всего
    //
    $.ajax
    (
        {
            url: infoUri,
            type: 'GET',
            dataType: 'json',
            success: function (data)
            {
                $("#InWork").text(data.InWork);
                $("#All").text(data.All);
            },
            error: function (e)
            {
            }

        }
    );
}

//
// Сделана / Не сделана
//
function toggleCheckbox(el)
{
    $.ajax
    (
        {
            url: todoUri+el.parentNode.nextSibling.nextSibling.textContent,
            type: 'PUT',
            dataType: 'json',
            success: function (data)
            {
                el.checked=data.Done;
                updateInfo();
            },
            error: function (e)
            {
            }
        }
    );
}

//
// Вставить задачу в таблицу
//
function insertTask(data)
{
    var pfx1='<tr></td><td><input type="checkbox" onclick="toggleCheckbox(this)"';
    var pfx2=' /></td><td>';
    var pfx3='</td><td style="display: none;">';
    var pfx4='</td></tr>';
    var chk='';
    if (data.Done) chk=' checked="checked"';
    $('#NewTask').before(pfx1+chk+pfx2+data.Name+pfx3+data.TaskId+pfx4)
    updateInfo();
}

//
// Добавить новую задачу
//
function addTask(el)
{
    if (confirm("Новая задача. Сохранить"))
    {
        var newTask=new NewTask(el.value);
        $.ajax
        (
            {
                url: todoUri,
                type: 'POST',
                dataType: 'json',
                data: newTask,
                success: function (data)
                {
                    el.value='';
                    insertTask(data);
                },
                error: function (e)
                {
                }
            }
        );
    }
}

//
// Получить список задач с сервар, отобразить в таблице
//
$(
    function ()
    {
        $.ajax
        (
            {
                url: todoUri,
                type: 'GET',
                dataType: 'json',
                success: function (data)
                {
                    for (var i=0; i<data.length; i++) insertTask(data[i]);
                },
                error: function (e)
                {
                    var test=e;
                }
            }
        );
    }
);
