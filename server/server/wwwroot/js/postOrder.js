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
         ids.push({"id": id, "count": count})
     }
     let req = {};
     req["productCount"] = ids;
     req["phoneNumber"] = document.getElementById("phone").value
     await fetch("https://localhost:7226/Order", {
         method: 'POST',
         headers: {
             'Accept': 'application/json',
             'Content-Type': 'application/json'
         },
         body: JSON.stringify(req)
     });

 }