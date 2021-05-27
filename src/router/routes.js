
const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '', component: () => import('pages/Index.vue') },
      { path: '/currency', component: () => import('pages/Currency.vue') },
      { path: '/currency/add', component: () => import('pages/CurrencyAdd.vue') },
      { path: '/currency/all', component: () => import('pages/CurrencyAll.vue') },
      { path: '/country', component: () => import('pages/Country/Index.vue') },
      { path: '/country/all', component: () => import('pages/Country/All.vue') },
      { path: '/country/add', component: () => import('pages/Country/Add.vue') },
      { path: '/company/add', component: () => import('pages/Company/Add.vue') },
      { path: '/company', component: () => import('pages/Company/Index.vue') },
      { path: '/company/all', component: () => import('pages/Company/All.vue') },
      { path: '/positions/all', component: () => import('pages/Position/Index.vue') },
      { path: '/banks/all', component: () => import('pages/Bank/Index.vue') },
      { path: '/bank-account/all', component: () => import('pages/BankAccount/Index.vue') },
      { path: '/bank-account/:accountNumber', component: () => import('pages/BankAccount/Account.vue') },
      { path: '/counterparty/all', component: () => import('pages/Counterparty/Index.vue') },
      { path: '/counterparty/:tin', component: () => import('pages/Counterparty/Counterparty.vue') },
      { path: '/store/storage-units', component: () => import('pages/Store/StorageUnits') },
      { path: '/store/product-categories', component: () => import('pages/Store/ProductKinds') },
      { path: '/partner', component: () => import('pages/Partner/Index') },
      { path: '/partner/all', component: () => import('pages/Partner/All') },
      { path: '/partner/:partnerId', component: () => import('pages/Partner/Partner') },
      { path: '/new-partner/create', component: () => import('pages/Partner/Create') },
      { path: '/agreement/:agreementId', component: () => import('pages/Agreement/Agreement') },
      { path: '/new-agreement/create', component: () => import('pages/Agreement/Create') },
      { path: '/marketing/business-proposal/all', component: () => import('pages/BusinessProposal/All') },
      { path: '/marketing/orders/all', component: () => import('pages/Order/All') },
      { path: '/marketing/view/order/:orderId', component: () => import('pages/Order/Order') },
      { path: '/marketing/business-proposal/view/:businessProposalId', component: () => import('pages/BusinessProposal/BusinessProposal') },
      { path: '/marketing/agreements/all', component: () => import('pages/Agreement/All') },
      { path: '/human-resources/employees/all', component: () => import('pages/HR/Employees') },
      { path: '/human-resources/employees/create', component: () => import('pages/HR/CreateEmployee') },
      { path: '/human-resources/employees/view/:employeeId', component: () => import('pages/HR/CreateEmployee') },
      { path: '/new-business-proposal', component: () => import('pages/BusinessProposal/Create'), name: 'BusinessProposalCreate' },
      { path: '/store/product/all', component: () => import('pages/Store/Products') },
      { path: '/marketing/order/create', component: () => import('pages/Order/Create') }
    ]
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '*',
    component: () => import('pages/Error404.vue')
  }
]

export default routes
