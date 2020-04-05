function onFindUserClick() {
    const el = document.querySelector('#find-user-btn');
    el.addEventListener('click', (event) => {
        event.preventDefault();
        const input = document.querySelector('#search');
        const params = new URLSearchParams({
            term: input.value,
        });
        console.log(`https://localhost:44360/api/FindUser/?${params.toString()}`);
        fetch(`https://localhost:44360/api/FindUsers?term=${input.value}`)
            .then(res => res.json())
            .then(res => {
                if (res == 'No users found') {

                }
                else {
                    const container = document.querySelector('#result-container');
                    container.innerHTML = '';
                    const fragment = document.createDocumentFragment();
                    const data = JSON.parse(res);
                    console.log(data);
                    data.forEach(ob => {
                        const linkContainer = document.createElement('div');
                        linkContainer.classList.add('mb-10');
                        const link = document.createElement('a');
                        link.style.color = 'white';
                        link.innerHTML = `${ob.FullName} (${ob.Email})`;
                        link.href = `https://localhost:44360/Profile/AnotherUser/${ob.Id}`;
                        linkContainer.appendChild(link);
                        fragment.appendChild(linkContainer);
                    })
                    console.log(container);
                    container.appendChild(fragment);
                }
            })
    })
}
onFindUserClick();