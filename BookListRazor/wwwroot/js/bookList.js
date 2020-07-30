let dataTable;

$(document).ready(function() {
    loadDataTable()
   
})
function loadDataTable() {
    console.log('loadDataTable')
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/Book",
            "type": "GET",
            "dataType": "json"
        },
        "columns": [
            { "data": "name", "width": "30%" },
            { "data": "author", "width": "30%" },
            { "data": "isbn", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                  
                    return `<div class="text-center"> 
                        <a href="/BookList/Upsert?id=${data}" class="btn btn-success tezt-white" style="cursor:pointer; width:100px">
                          Edit
                        </a>
                      <a  class="btn btn-danger tezt-white" style="cursor:pointer; width:100px" onClick=Delete('api/Book?id=${data}')>
                          Delete
                        </a>
</div>`
                }, "width":"30%"
            }
        ],
        "language": "no data found",
        "width":"100%"

    })
   
}
function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "you won't be able to recover",
        icon: "warning",
         buttons:true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: url,
                type: "Delete",
                dataType: "json",
                success: function (data) {
                    console.log(data.success)
                    if (data.success) {
                        toastr.success(data.message)
                        dataTable.ajax.reload();
                        console.log('123')
                    }
                    else {
                        toastr.error(data.message)
                    }
                }
            })
        }

    });



  
}