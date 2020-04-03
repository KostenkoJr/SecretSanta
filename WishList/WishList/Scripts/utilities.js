class Notifier {

    static showSuccess(title, message) {
        $.notify(
            {
                title: title,
                icon: './../Content/assets/img/logo/2.png',
                message: message,

            },
            {
                type: 'success',
                icon_type: 'image',
                placement: {
                    from: "bottom",
                    align: "right"
                },
                delay: 3000
            })
    }

    static showWarning(title, message) {
        $.notify(
            {
                title: title,
                icon: './../Content/assets/img/coming-soon/userIsntFoundIcon.png',
                message: message,

            },
            {
                type: 'danger',
                icon_type: 'image',
                placement: {
                    from: "bottom",
                    align: "right"
                },
                delay: 3000
            })
    }

}


class AjaxRequest {
    static ajaxSendForm(obj, url) {
        const promise = fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json', // отправляемые данные
            },
            body: JSON.stringify(obj),

        })
        return promise;
    };
}