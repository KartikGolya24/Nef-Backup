const PurchaseFlowService = {
  checkAddress(addressId) {
    return new Promise((resolve, reject) => {
      fetch("/purchase-flow/check-address?adresseGUID=" + addressId).then(data => {
        resolve(data.json());
      }).catch(error => reject(error))
    })
  },
  availableDates(orderType,addressId) {
    return new Promise((resolve, reject) => {
      fetch("/purchase-flow/get-calendar-dates?orderType=" + orderType +"&adresseguid=" + addressId).then(data => {
        resolve(data.json());
      }).catch(error => reject(error))
    })
  },
  getTvPackages() {
    return new Promise((resolve, reject) => {
      fetch("/packages/get-tv-package-list").then(data => {
        resolve(data.json());
      }).catch(error => reject(error))
    })
  },
  getFiberPackages() {
    return new Promise((resolve, reject) => {
      fetch("/packages/get-fiber-package-list").then(data => {
        resolve(data.json());
      }).catch(error => reject(error))
    })
  },
  submitForm(model) {
    return new Promise((resolve, reject) => {
      fetch("/purchase-flow/send-product-data-to-client-api", {
        method: "POST",
        headers: {
          'content-type': "application/json",
        },
        body:JSON.stringify(model)
      }).then((response) => {
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        resolve(response.json);
      }).catch((error) => {
        console.error('Error:', error); 
        reject(error)
      });
    })
  },

}

export default PurchaseFlowService;
