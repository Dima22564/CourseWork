<template>
  <div>
    <q-table
      :data="data"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="loading"
      no-data-label="Нет данных"
    >
      <template v-slot:top>
        <div class="flex justify-between flex-center" style="width: 100%">
          <h6 class="q-ma-none">Лицензии на торговлю алкоголем</h6>
          <q-btn @click="addLicense = true" v-if="!isCreation" size="sm" color="secondary" :icon="icons.mdiPlus" label="партнера" />
          <q-btn @click="createLicense = true" v-if="isCreation" size="sm" color="secondary" :icon="icons.mdiPencil" label="партнера" />
        </div>
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="name" :props="props">
            {{ props.row.number }}
          </q-td>

          <q-td key="issuedBy" :props="props">
            {{ props.row.issuedBy }}
          </q-td>

          <q-td key="address" :props="props">
            {{ props.row.address }}
          </q-td>

          <q-td key="kind" :props="props">
            {{ props.row.kind }}
          </q-td>

          <q-td key="validFrom" :props="props">
            {{ props.row.validFrom }}
          </q-td>

          <q-td key="validTo" :props="props">
            {{ props.row.validTo }}
          </q-td>

          <q-td key="status" :props="props">
            {{ props.row.status }}
          </q-td>

          <q-td key="actions" :props="props">
            <q-btn color="deep-orange" size="sm" label="Аннулировать" @click="cancel(props.row.number)" :loading="loading" />
            <q-btn color="purple" size="sm" label="Отправить на проверку" @click="sendToCheckLicense(props.row.number)" :loading="loading" />
            <q-btn class="q-ml-sm" color="secondary" size="sm" label="Просмотр" @click="getLicense(props.row.number)" :loading="loading" />
          </q-td>
        </q-tr>
      </template>
    </q-table>

    <q-dialog v-model="addPartner" v-if="!isCreation" persistent>
      <q-card style="width: 700px;">
        <q-card-section class="row items-center justify-between">
          <span class="q-ma-none text-h6">Добавить лицензию на торговлю алкоголем.</span>
        </q-card-section>

        <AddBankAccountPopup />

        <q-card-actions align="right">
          <q-btn flat label="Закрыть" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>

    <q-dialog v-model="createPartner" v-if="isCreation" persistent>
      <q-card style="width: 700px;">
        <q-card-section class="row items-center justify-between">
          <span class="q-ma-none text-h6">Создание партнера.</span>
        </q-card-section>

        <AddBankAccountPopup />

        <q-card-actions align="right">
          <q-btn flat label="Закрыть" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>
  </div>
</template>

<script>
import AddBankAccountPopup from 'components/addingElements/AddBankAccountPopup'
import icons from 'src/mixins/icons'
export default {
  components: {
    AddBankAccountPopup
  },
  mixins: [icons],
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
  methods: {
    cancel (number) {
    },
    getLicense (number) {
      this.$router.push('/license/' + number)
    },
    sendToCheckLicense (number) {
    }
  },
  data: () => {
    return {
      loading: false,
      addPartner: false,
      createPartner: false,
      columns: [
        { name: 'number', label: '№', align: 'left', field: 'number' },
        { name: 'validFrom', label: 'Дата начала действия', field: 'validFrom' },
        { name: 'validTo', label: 'Дата окончания действия', field: 'validTo' },
        { name: 'issuedBy', label: 'Кем выдана', field: 'issuedBy' },
        { name: 'kind', label: 'Вид лицензии', field: 'kind' },
        { name: 'status', label: 'Статус', field: 'status' },
        { name: 'actions', label: '', field: 'actions' }
      ]
    }
  }
}
</script>
