class Notifier {
    static showSuccess(title, message) {
        $.notify({
            title: title,
            icon: './../Content/assets/img/logo/2.png',
            message: message,
            
        },
        {
            type: 'success',
            icon_type: 'image',
            //offset: {
            //    x: 20,
            //    y: 80
            //},
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
        
        //formData.append('form', formData);
        //console.log(JSON.stringify(formData));
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