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
  }
}

export default PurchaseFlowService;
