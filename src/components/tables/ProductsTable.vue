<template>
  <div>
    <q-table
      title="Товары"
      :data="data"
      :columns="columns"
      row-key="name"
      binary-state-sort
      no-data-label="Нет данных"
    >
      <template v-slot:top>
        <div class="flex justify-between flex-center" style="width: 100%">
          <h6 class="q-ma-none">Товары</h6>
          <q-btn class="q-ml-auto q-mr-sm" @click="createCounterparty = true" size="sm" color="secondary" :icon="icons.mdiPlus" label="добавить товар" />
          <q-btn v-if="$route.query.createBp" @click="$router.push('/new-business-proposal?number=' + $route.query.number)" size="sm" color="deep-orange" label="Вернуться к КП" />
        </div>
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="productId" :props="props">
            {{ props.row.productId }}
          </q-td>

          <q-td key="workName" :props="props">
            {{ props.row.workName }}
          </q-td>

          <q-td key="price" :props="props">
            {{ props.row.price }}
          </q-td>

          <q-td key="quantity" :props="props">
            {{ props.row.quantity }}
          </q-td>

          <q-td v-if="$route.query.createBp" key="actions" :props="props">
            <q-btn v-if="!bpProducts.find(x => x.productId === props.row.productId)" @click="addToBp(props.row.productId)" size="sm" color="positive" icon="shopping_cart" />
          </q-td>

        </q-tr>

      </template>
    </q-table>

    <q-dialog v-model="createCounterparty" persistent>
      <q-card style="width: 700px;">
        <q-card-section class="row items-center justify-between">
          <span class="q-ml-sm text-h6">Добавить товар</span>
        </q-card-section>

        <create-product />

        <q-card-actions align="right">
          <q-btn flat label="Закрыть" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>

  </div>
</template>

<script>
import icons from 'src/mixins/icons'
import CreateProduct from 'components/creationElements/CreateProduct'
export default {
  name: 'ProductsTable',
  components: {
    CreateProduct
  },
  mixins: [icons],
  methods: {
    addToBp (productId) {
      const product = this.$store.state.product.products.find(x => x.productId === productId)
      this.$store.commit('businessProposal/addProduct', product)
    }
  },
  computed: {
    bpProducts () {
      return this.$store.state.businessProposal.businessProposalProducts
    }
  },
  props: {
    data: {
      type: Array,
      default: () => []
    },
    isCreation: {
      type: Boolean,
      default: () => true
    }
  },
  data: () => {
    return {
      loading: false,
      createCounterparty: false,
      columns: [
        { name: 'productId', label: '#', align: 'left', field: 'productId' },
        { name: 'workName', label: 'Название', field: 'workName' },
        { name: 'price', label: 'Цена', field: 'price' },
        { name: 'quantity', label: 'Кол-во', field: 'quantity' },
        { name: 'actions', label: '', field: 'actions' }
      ]
    }
  }
}
</script>
