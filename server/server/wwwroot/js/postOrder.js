async function PostOrder() {
    const cartWrapper = document.querySelector(".cart-wrapper");
    let ids = [];
    console.log(cartWrapper)
    const items = cartWrapper.getElementsByClassName("cart-item");
    console.log(items)
    for (let i = 0; i < items.length; i++) {
        let item = items[i]
        let id = +item.getAttribute("data-id");
        let count = +item.querySelector("[data-counter]").innerText;
        ids.push({ "id": id, "count": count })
    }
    let req = {};
    req["productCount"] = ids;
    req["phoneNumber"] = document.getElementById("phone").value;

    const response = await fetch("https://localhost:7226/Order", {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(req)
    });

    if (response.ok) {
        const data = await response.json();

        let modalContent = `<p>Ваш заказ №${data} принят, ожидайте звонка</p>`;
        modalContent += '<button type="button" class="btn btn-primary" data-dismiss="modal">Ok</button>';

        let modal = document.createElement("div");
        modal.classList.add("modal", "fade");
        modal.innerHTML = `
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    ${modalContent}
                </div>
            </div>
        </div>
    `;

        document.body.appendChild(modal);

        while (cartWrapper.firstChild) {
            cartWrapper.firstChild.remove();
        }
        
        toggleCartStatus();
        calcCartPriceAndDelivery();
        
        jQuery(modal).modal("show");
    }
}