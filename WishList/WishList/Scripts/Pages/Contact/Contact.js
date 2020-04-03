/*--------------------Events--------------------*/
function onSendFeedbackForm() {
    const sendBtn = document.querySelector('#SendForm');
    sendBtn.addEventListener('click', (event) => {
        event.preventDefault();
        const formData = document.querySelector('#GetInTouch');
        const data = {};
        const arr = Array.from(formData.elements);
        arr.forEach(el => {
            data[el.name] = el.value;
        });
        const promise = AjaxRequest.ajaxSendForm(data, 'https://localhost:44360/api/GetInTouch');
        promise
            .then(res => {
                Notifier.showSuccess('<strong>Your message is sent!</strong>', '');
            })
            .catch(err => {
                console.log(err)
            })
    });
}
onSendFeedbackForm();