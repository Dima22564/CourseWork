import Vue from 'vue'
/*
export function someMutation (state) {
}
*/

export function setAll (state, data) {
  state.businessProposals = data
}

export function add (state, data) {
  state.businessProposals.push(data)
}

export function addProduct (state, product) {
  Vue.set(product, 'sale', 0)
  state.businessProposalProducts.push(product)
}

export function changeStep (state, step) {
  state.step = step
}

export function deleteProduct (state, productId) {
  state.businessProposalProducts = state.businessProposalProducts.filter(x => x.productId !== productId)
}

export function setProducts (state, products) {
  state.businessProposalProducts = products
}

export function update (state, data) {
  const bpProduct = state.businessProposalProducts.find(x => x.productId === data.productId)
  bpProduct[data.propName] = data.val
}
