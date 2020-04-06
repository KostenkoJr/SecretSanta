/*--------------------Events--------------------*/
function onUploadImageWish() {
    const inputFile = document.getElementById('file-input-image');
    const wishId = inputFile.dataset.wish;
    inputFile.addEventListener('change', (event) => {
        event.preventDefault();
        var dataFile = new FormData();
        dataFile.append('file', inputFile.files[0]);
        dataFile.append('wishId', wishId);
        fetch("https://localhost:44360/api/UploadImage", {

            method: 'POST',
            body: dataFile
        })
            .then(res => res.json())
            .then(src => {
                const itemPic = document.querySelector('.item-pic');
                itemPic.src = `/Files/${src}`;
            });

    })
}
onUploadImageWish();

function onSaveChangesDetailsWish() {
    function validateForm(arr) {
        let counter = 0;
        arr.forEach(input => {
            if (input.name != 'Description' && input.name != 'LinkToShop' ) {
                if (input.value === null || input.value.trim() === '' || typeof input.value === 'undefined') {
                    counter++;
                    input.classList.toggle('no-valid', true);
                }
                else {
                    input.classList.toggle('no-valid', false);
                }
            }
        })
        return counter > 0 ? false : true;
    }
    const sendBtn = document.querySelector('.save-changes');
    sendBtn.addEventListener('click', (event) => {
        event.preventDefault();
        const formData = document.querySelector('#SaveChanges');
        const img = document.querySelector('.item-pic');
        const data = {};
        const arr = Array.from(formData.elements);
        const isValid = validateForm(arr);
        if (isValid === false) {
            return;
        }
        arr.forEach(el => {
            data[el.name] = el.value;
        });
        let pathToPicture = img.src.match(/Files\/.*/gi)[0].substring(6);
        data["pathToPicture"] = pathToPicture;
        const promise = AjaxRequest.ajaxSendForm(data, 'https://localhost:44360/api/ChangeWish');
        promise
            .then(res => {
                const closeBtn = document.querySelector('.close');
                const wishImg = document.querySelector(`#img${data.Id}`);
                wishImg.src = "/Files/" + pathToPicture;
                const wishTitle = document.querySelector(`#title${data.Id}`);
                wishTitle.innerHTML = data.Title;
                closeBtn.click();
                Notifier.showSuccess("<strong>Wish changed!</strong>", '<br><p>Your wish was changed!</p>')
            })
            .catch(err => {
                console.log(err)
            })
    });
}
onSaveChangesDetailsWish();
