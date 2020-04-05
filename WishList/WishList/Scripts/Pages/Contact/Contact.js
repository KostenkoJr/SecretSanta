/*--------------------Events--------------------*/
function onSendFeedbackForm() {
    const sendBtn = document.querySelector('#SendForm');
    sendBtn.addEventListener('click', (event) => {
        event.preventDefault();
        const formData = document.querySelector('#GetInTouch');
        const data = {};
        const arr = Array.from(formData.elements);
        const isValid = validateForm(arr);
        if (isValid === false)
            return;
        arr.forEach(el => {

            data[el.name] = el.value;
        });
        const promise = AjaxRequest.ajaxSendForm(data, 'https://localhost:44360/api/GetInTouch');
        promise
            .then(res => {
                Notifier.showSuccess('<strong>Your message is sent!</strong>');
            })
            .catch(err => {
                console.log(err)
            })
        resetForm(arr);
    });
}
onSendFeedbackForm();

/*--------------------Help functions--------------------*/
function resetForm(arr) {
    arr.forEach(inp => {
        if (inp.id !== 'SendForm') {
            inp.value = '';
        }
    })
}

function validateForm(arr) {
    let counter = 0;
    arr.forEach(input => {
        if (input.id !== 'SendForm') {
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