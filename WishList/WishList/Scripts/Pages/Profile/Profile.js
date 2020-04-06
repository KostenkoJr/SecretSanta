/*-------------------Modal-------------------*/
//Modal "Details"
$(function () {
    $.ajaxSetup({ cache: false });
    $(".modalka").click(function (e) {

        e.preventDefault();
        $.get(this.href, function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });
});

//Modal "Add Wish"
$(function () {
    $(function () {
        $.ajaxSetup({ cache: false });
        $(".add-wish-modal").click(function (e) {
            e.preventDefault();
            $.get(this.href, function (data) {
                $('#dialogContent1').html(data);
                $('#modDialog1').modal('show');
            });
        });
    })
})

/*-------------------Events-------------------*/
function onDOMContentLoaded() {
    document.addEventListener('DOMContentLoaded', (event) => {
        const formData = document.querySelector('#SaveChangesDetails');
        formData.addEventListener('change', (event) => {
            const data = {};
            const arr = Array.from(formData.elements);
            arr.forEach(el => {
                data[el.name] = el.value;
            });
            const saveChangesBtn = document.querySelector('#save-changes-btn');
            if (JSON.stringify(data) === localStorage.getItem('form-details-cast')) {
                saveChangesBtn.classList.toggle('disable-btn', true);
                saveChangesBtn.classList.toggle('cr-btn', false);
            }
            else {
                saveChangesBtn.classList.toggle('disable-btn', false);
                saveChangesBtn.classList.toggle('cr-btn', true);
            }
        })
        const data = {};
        const arr = Array.from(formData.elements);
        arr.forEach(el => {
            data[el.name] = el.value;
        });
        localStorage.setItem('form-details-cast', JSON.stringify(data));
    });
}
onDOMContentLoaded();

function onChangeStatus() {
    const el = document.querySelectorAll(".ti-check");
    el.forEach(e => {
        e.addEventListener('click', (event) => {
            event.preventDefault();
            const target = event.target;
            const id = target.id;
            const promise = fetch(`https://localhost:44360/api/ChangeStatus/${id}`);
            promise.then(res => res.json()).then(isComplete => {
                const elDone = document.querySelector(`#wish${target.id}`)
                elDone.classList.toggle('done');
                elDone.classList.toggle('not-done');
                elDone.innerHTML = isComplete ? 'Done' : 'Not Done'
            });
        })
    })
}
onChangeStatus();

function onChangePassword() {
    const element = document.querySelector('.change-password');
    const data = {};
    element.addEventListener('click', (event) => {
        event.preventDefault();
        //--------------------------------------------------------------------------
        const passwordForm = document.querySelector('#ChangePassword');
        const data = {};
        const arr = Array.from(passwordForm.elements);
        if (arr[1].value.length <= 6) {
            arr.forEach(el => {
                el.value = '';
            });
            Notifier.showWarning('Password mismatch', '<br><p>Password must be longer than 6 characters</p>');
            return;
        }
        if (arr[1].value !== arr[2].value) {
            arr.forEach(el => {
                el.value = '';
            });
            Notifier.showWarning('Password mismatch', '123');
            return;
        }

        arr.forEach(el => {
            data[el.name] = el.value;
        });
        fetch("https://localhost:44360/api/ChangePassword", {

            method: 'POST',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        }).then(res => res.json())
            .then(data => {
                if (data == 'Incorrect password') {
                    Notifier.showWarning("<strong>Password incorrect</strong>", '<br><p></p>')
                }
                if (data == 'Password mismatch') {
                    Notifier.showWarning("<strong>Password mismatch</strong>", '<br><p></p>')
                }
                if (data == 'Success') {
                    Notifier.showSuccess("<strong>Password updated</strong>", '<br><p></p>')
                }
                arr.forEach(el => {
                    el.value = '';
                });
            })
    })
}
onChangePassword();

//TODO Рефакторинг
function onChangeAvatar() {
    const inputFile = document.getElementById('file-input');
    inputFile.addEventListener('change', (event) => {
        var dataFile = new FormData();
        dataFile.append('file', inputFile.files[0])
        fetch("https://localhost:44360/api/ChangeAvatar", {
            method: 'POST',
            body: dataFile
        })
            .then(res => res.json())
            .then(src => {
                const imgAvatar = document.querySelector('#avatar');
                imgAvatar.src = `/Files/${src}`;
            });

    })
}
onChangeAvatar();

function onSaveChangesProfileDetails() {
    const saveChangesBtn = document.querySelector('#save-changes-btn');
    saveChangesBtn.addEventListener('click', (event) => {
        event.preventDefault();
        if (saveChangesBtn.classList.contains('disable-btn'))
            return;
        const formData = document.querySelector('#SaveChangesDetails');
        const data = {};
        const arr = Array.from(formData.elements);
        arr.forEach(el => {
            data[el.name] = el.value;
        });
        const promise = AjaxRequest.ajaxSendForm(data, 'https://localhost:44360/api/ChangeProfileDetails');
        promise
            .then(res => {
                Notifier.showSuccess("<strong>Details updated!</strong>", '<br><p>Your prifile details were changed!</p>')
                localStorage.setItem('form-details-cast', JSON.stringify(data));
                saveChangesBtn.classList.toggle('disable-btn', true);
            })
            .catch(err => {
                console.log(err)
            })
    });
}
onSaveChangesProfileDetails();

function onDeleteWish() {
    const deleteIcon = document.querySelectorAll(".action-trash");
    deleteIcon.forEach(e => {
        e.addEventListener('click', (event) => {
            event.preventDefault();
            const target = event.target;
            const id = target.id;
            const title = target.dataset.title;
            $('#ConfirmModal').modal('show');
            document.querySelector('#modal-body').innerHTML = `Are you sure you want to delete "${title}?"`

            const confirmBtn = document.querySelector('#confirm-btn');
            confirmBtn.onclick = (event) => {
                event.preventDefault();
                fetch(`https://localhost:44360/api/DeleteWish/${id}`)
                    .then(res => {
                        $('#ConfirmModal').modal('hide');
                        document.querySelector(`#WishId${id}`).remove();
                        Notifier.showSuccess('Delete success', `<p><br>Wish "${title}" was deleted</p>`);
                    });
            };
        })
    })
}
onDeleteWish();

function onMakeMagic() {
    const el = document.querySelector('#MakeMagic');
    if (el) {
        el.addEventListener('click', (event) => {
            event.preventDefault();
            if (el.classList.contains('disable-btn'))
                return;
            fetch('https://localhost:44360/api/MakeMagic')
                .then(res => res.json())
                .then(data => {
                    el.classList.toggle('disable-btn', true);
                    el.classList.toggle('cr-btn', false);
                });
        })
    }

}
onMakeMagic();