
//Button used to call a post on the API
$("#postButton").click(function ()
{
    //Checks if data is valid on the front end
    if ($("#newUserId").val().length == 0 || $("#newFname").val().length == 0 || $("#newLname").val().length == 0 || $("#newAge").val().length == 0)
    {
        alert("Empty field please correct");
    }
    else if (Number($("#newAge").val()) != Math.floor($("#newAge").val()))
    {
        alert("Value in Age field is not a number");
    }
    //Once all data is validated and correct run this else statement to Post the account to the local DB
    else
    {
        var acc = {
            user_id: $("#newUserId").val().toString(),
            f_name: $("#newFname").val().toString(),
            l_name: $("#newLname").val().toString(),
            age: parseInt($("#newAge").val())
        }

        $.ajax({
            url: "api/Account",
            type: "POST",
            data: JSON.stringify(acc),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
        });
    }     
})


//Button to use the get API call
$("#getButton").click(function ()
{
    $("#accountTable tbody").empty();
    //Checks to see if they want to see all accounts or just one
    if ($("#getAccount").val().length == 0) {
        let getaccounts = $.getJSON("api/Account", function (json_data)
        {
            console.log(json_data);

            //Loops through each object inside of json_data
            $.each(json_data, function (index) {
                let u_id = json_data[index].user_id;
                let f_name = json_data[index].f_name;
                let l_name = json_data[index].l_name;
                let age = json_data[index].age;
                let row = '<tr><td>' + u_id + '</td><td>' + f_name + '</td><td>'
                    + l_name + '</td><td>' + age + '</td></tr>';

                $("#accountTable").append(row);
                row = '';

            })

        })
            .done(function () {
                console.log("Get all accounts success");
            });
    }
    //Looks for the one account with the specified Id in the getAccount input text field
    else
    {
        url = 'api/Account/' + $("#getAccount").val();
        let getaccount = $.getJSON(url, function (json_data)
        {
            console.log(json_data);

            //Loops through each object inside of json_data
            let u_id = json_data.user_id;
            let f_name = json_data.f_name;
            let l_name = json_data.l_name;
            let age = json_data.age;
            let row = '<tr><td>' + u_id + '</td><td>' + f_name + '</td><td>'
                + l_name + '</td><td>' + age + '</td></tr>';

            $("#accountTable").append(row);
            row = '';
        })
            .done(function ()
            {
                console.log("Get account success");
            });
    }
})

//Delete Button on click event
$("#deleteButton").click(function () {
    var id = $("#delUserId").val();

    $.ajax({
        url: "api/Account/" + id,
        type: "DELETE"
    })
});
