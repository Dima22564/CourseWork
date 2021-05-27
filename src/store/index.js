import Vue from 'vue'
import Vuex from 'vuex'

// import example from './module-example'
import currency from './currency'
import country from './country'
import bank from './bank'
import counterparty from './counterparty'
import bankAccount from './bankAccount'
import partner from './partner'
import businessProposal from './businessProposal'
import position from './position'
import product from './product'
import agreement from './agreement'

Vue.use(Vuex)

/*
 * If not building with SSR mode, you can
 * directly export the Store instantiation;
 *
 * The function below can be async too; either use
 * async/await or return a Promise which resolves
 * with the Store instance.
 */

export default function (/* { ssrContext } */) {
  const Store = new Vuex.Store({
    modules: {
      currency,
      country,
      bank,
      counterparty,
      bankAccount,
      partner,
      businessProposal,
      position,
      product,
      agreement
    },

    // enable strict mode (adds overhead!)
    // for dev mode only
    strict: process.env.DEBUGGING
  })

  return Store
}
